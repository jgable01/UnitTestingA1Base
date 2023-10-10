using UnitTestingA1Base.Models;

namespace UnitTestingA1Base.Data
{
    public class BusinessLogicLayer
    {
        private AppStorage _appStorage;

        public BusinessLogicLayer(AppStorage appStorage)
        {
            _appStorage = appStorage;
        }
        public HashSet<Recipe> GetRecipesByIngredient(int? id, string? name)
        {
            Ingredient ingredient = null;

            if (id.HasValue)
            {
                ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Id == id);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Name.Contains(name));
            }

            if (ingredient == null) return new HashSet<Recipe>();

            HashSet<RecipeIngredient> recipeIngredients = _appStorage.RecipeIngredients.Where(rI => rI.IngredientId == ingredient.Id).ToHashSet();
            return new HashSet<Recipe>(_appStorage.Recipes.Where(r => recipeIngredients.Any(ri => ri.RecipeId == r.Id)));
        }
        public HashSet<Recipe> GetRecipesByDietaryRestriction(int id, string name)
        {
            HashSet<Ingredient> restrictedIngredients = new HashSet<Ingredient>(
                _appStorage.IngredientRestrictions
                    .Where(ir => ir.DietaryRestrictionId == id)
                    .Select(ir => _appStorage.Ingredients.First(i => i.Id == ir.IngredientId))
            );

            return new HashSet<Recipe>(
                _appStorage.RecipeIngredients
                    .Where(ri => restrictedIngredients.Any(i => i.Id == ri.IngredientId))
                    .Select(ri => _appStorage.Recipes.First(r => r.Id == ri.RecipeId))
            );
        }
        public HashSet<Recipe> GetRecipesByIdOrName(int id, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return new HashSet<Recipe>(_appStorage.Recipes.Where(r => r.Name.Contains(name)));
            }
            return new HashSet<Recipe>(_appStorage.Recipes.Where(r => r.Id == id));
        }
        public void AddNewRecipeWithIngredients(RecipeWithIngredients newRecipe)
        {
            // Check if a recipe with the same name already exists
            if (_appStorage.Recipes.Any(r => r.Name == newRecipe.Recipe.Name))
                throw new InvalidOperationException("Recipe with the same name already exists.");

            // Generate an ID for the new recipe and add it to storage
            newRecipe.Recipe.Id = _appStorage.GeneratePrimaryKey();
            _appStorage.Recipes.Add(newRecipe.Recipe);

            // Iterate over each ingredient detail in the newRecipe
            foreach (var ingredientDetail in newRecipe.Ingredients)
            {
                var existingIngredient = _appStorage.Ingredients.FirstOrDefault(i => i.Name == ingredientDetail.Name);

                // If ingredient doesn't exist in storage, generate an ID for it and add
                if (existingIngredient == null)
                {
                    ingredientDetail.Id = _appStorage.GeneratePrimaryKey();
                    _appStorage.Ingredients.Add(ingredientDetail);
                }
                else
                {
                    ingredientDetail.Id = existingIngredient.Id;
                }

                // Add RecipeIngredient relationship
                _appStorage.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = newRecipe.Recipe.Id,
                    IngredientId = ingredientDetail.Id
                });
            }
        }

        public void DeleteIngredient(int id, string name)
        {
            Ingredient ingredient = _appStorage.Ingredients.First(i => i.Id == id || i.Name == name);
            var recipeIngredients = _appStorage.RecipeIngredients.Where(ri => ri.IngredientId == ingredient.Id).ToList();

            if (GetRecipesByIngredient(id, name).Count > 1)
            {
                throw new InvalidOperationException("Ingredient is used in multiple recipes.");
            }

            foreach (var recipeIngredient in recipeIngredients)
            {
                _appStorage.RecipeIngredients.Remove(recipeIngredient);
            }
            _appStorage.Ingredients.Remove(ingredient);
        }
        public void DeleteRecipe(int id, string name)
        {
            Recipe recipe = _appStorage.Recipes.First(r => r.Id == id || r.Name == name);
            var recipeIngredients = _appStorage.RecipeIngredients.Where(ri => ri.RecipeId == recipe.Id).ToList();

            foreach (var recipeIngredient in recipeIngredients)
            {
                _appStorage.RecipeIngredients.Remove(recipeIngredient);
            }
            _appStorage.Recipes.Remove(recipe);
        }

        public bool CheckIfIngredientExists(int ingredientId)
        {
            return _appStorage.Ingredients.Any(i => i.Id == ingredientId);
        }


    }
}
