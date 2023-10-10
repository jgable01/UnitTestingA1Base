using UnitTestingA1Base.Models;

namespace UnitTestingA1Base.Data
{
    /// <summary>
    /// Class that instantiates and stores all of the Recipes, Ingredients, Dietary Restrictions, and many-to-many relationships between these classes.
    /// A single Ingredient may fulfill multiple Dietary Restrictions and vice-versa. Similarly, Recipes use many Ingredients and vice-versa.
    /// 
    /// Note that multi-table queries (e.g. Includes methods) are not available for these collections and manual joins are required.
    /// </summary>

    public class AppStorage
    {
        private int _idCount = 256;
        public HashSet<Recipe> Recipes { get; set; }
        public HashSet<DietaryRestriction> DietaryRestrictions { get; set; }
        public HashSet<Ingredient> Ingredients { get; set; }
        public HashSet<IngredientRestriction> IngredientRestrictions { get; set; }
        public HashSet<RecipeIngredient> RecipeIngredients { get; set; }

        public int GeneratePrimaryKey()
        {
            return _idCount++;
        }
        public AppStorage()
        {
            Recipes = new HashSet<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Name = "Spaghetti Carbonara",
                Description = "Classic Roman pasta dish with eggs, cheese, and pancetta.",
                Servings = 2
            },
            new Recipe
            {
                Id = 2,
                Name = "Chicken Alfredo",
                Description = "Creamy pasta dish with grilled chicken and Parmesan cheese sauce.",
                Servings = 4
            },
            new Recipe
            {
                Id = 3,
                Name = "Caprese Salad",
                Description = "Fresh salad with tomatoes, mozzarella, and basil, drizzled with balsamic glaze.",
                Servings = 2
            },
            new Recipe
            {
                Id = 4,
                Name = "Margherita Pizza",
                Description = "Classic Italian pizza with tomatoes, mozzarella, and basil leaves.",
                Servings = 2
            },
            new Recipe
            {
                Id = 5,
                Name = "Beef Tacos",
                Description = "Tacos with seasoned ground beef, lettuce, tomatoes, and cheese.",
                Servings = 4
            },
            new Recipe
            {
                Id = 6,
                Name = "Vegetable Stir Fry",
                Description = "Quick and healthy stir fry with assorted vegetables.",
                Servings = 4
            },
            new Recipe
            {
                Id = 7,
                Name = "Grilled Salmon",
                Description = "Delicious grilled salmon fillet with lemon and herbs.",
                Servings = 2
            },
            new Recipe
            {
                Id = 8,
                Name = "Mushroom Risotto",
                Description = "Creamy Italian rice dish with mushrooms and Parmesan cheese.",
                Servings = 3
            },
            new Recipe
            {
                Id = 9,
                Name = "Chocolate Cake",
                Description = "Classic chocolate cake with rich chocolate frosting.",
                Servings = 8
            },
            new Recipe
            {
                Id = 10,
                Name = "Cucumber Salad",
                Description = "Refreshing salad with cucumbers, red onions, and dill.",
                Servings = 4
            },
            new Recipe
        {
            Id = 11,
            Name = "Vegetable Stir Fry",
            Description = "Quick and healthy stir fry with assorted vegetables.",
            Servings = 4
        }, new Recipe {
                Id = 12,
                Name = "Grilled Salmon",
                Description = "Delicious grilled salmon fillet with lemon and herbs.",
                Servings = 2
            }
        };

            DietaryRestrictions = new HashSet<DietaryRestriction>
        {
            new DietaryRestriction
            {
                Id = 1,
                Name = "Vegetarian"
            },
            new DietaryRestriction
            {
                Id = 2,
                Name = "Vegan"
            },
            new DietaryRestriction
            {
                Id = 3,
                Name = "Gluten-Free"
            },
            new DietaryRestriction
            {
                Id = 4,
                Name = "Nut-Free"
            },
            new DietaryRestriction
            {
                Id = 5,
                Name = "Lactose-Free"
            }
        };

            Ingredients = new HashSet<Ingredient>
        {
            new Ingredient
            {
                Id = 1,
                Name = "Spaghetti"
            },
            new Ingredient
            {
                Id = 2,
                Name = "Eggs"
            },
            new Ingredient
            {
                Id = 3,
                Name = "Pancetta"
            },
            new Ingredient
            {
                Id = 4,
                Name = "Tomatoes"
            },
            new Ingredient
            {
                Id = 5,
                Name = "Ground Beef"
            },
            new Ingredient
            {
                Id = 6,
                Name = "Salmon"
            },
            new Ingredient
            {
                Id = 7,
                Name = "Arborio Rice"
            },
            new Ingredient
            {
                Id = 8,
                Name = "Parmesan Cheese"
            },
            new Ingredient
            {
                Id = 9,
                Name = "Cocoa Powder"
            },
            new Ingredient
            {
                Id = 10,
                Name = "Cucumbers"
            }
        };

            RecipeIngredients = new HashSet<RecipeIngredient>
        {
    new RecipeIngredient
    {
        IngredientId = 1,
        RecipeId = 1,
        Amount = 200,
        MeasurementUnit = MeasurementUnit.Grams
    },
    new RecipeIngredient
    {
        IngredientId = 1, // Spaghetti
        RecipeId = 2,     // Chicken Alfredo
        Amount = 250,     // Arbitrary amount
        MeasurementUnit = MeasurementUnit.Grams
    },
            new RecipeIngredient
            {
                IngredientId = 3,
                RecipeId = 1,
                Amount = 50,
                MeasurementUnit = MeasurementUnit.Grams
            },
            new RecipeIngredient
            {
                IngredientId = 4,
                RecipeId = 3,
                Amount = 4,
                MeasurementUnit = MeasurementUnit.Milliletres
            },
            new RecipeIngredient
            {
                IngredientId = 5,
                RecipeId = 5,
                Amount = 400,
                MeasurementUnit = MeasurementUnit.Grams
            },
            new RecipeIngredient
            {
                IngredientId = 6,
                RecipeId = 7,
                Amount = 250,
                MeasurementUnit = MeasurementUnit.Grams
            },
            new RecipeIngredient
            {
                IngredientId = 7,
                RecipeId = 8,
                Amount = 200,
                MeasurementUnit = MeasurementUnit.Grams
            },
            new RecipeIngredient
            {
                IngredientId = 8,
                RecipeId = 8,
                Amount = 100,
                MeasurementUnit = MeasurementUnit.Grams
            },
            new RecipeIngredient
            {
                IngredientId = 9,
                RecipeId = 9,
                Amount = 150,
                MeasurementUnit = MeasurementUnit.Grams
            },
            new RecipeIngredient
            {
                IngredientId = 10,
                RecipeId = 10,
                Amount = 300,
                MeasurementUnit = MeasurementUnit.Grams
            },
                new RecipeIngredient
        {
            IngredientId = 6,
            RecipeId = 12,
            Amount = 250,
            MeasurementUnit = MeasurementUnit.Grams
        },
           new RecipeIngredient
            {
                IngredientId = 7,
                RecipeId = 12,
                Amount = 150,
                MeasurementUnit = MeasurementUnit.Grams
            },

            new RecipeIngredient
            {
                IngredientId = 8,
                RecipeId = 11,
                Amount = 200,
                MeasurementUnit = MeasurementUnit.Grams
            },

            new RecipeIngredient
            {
                IngredientId = 9,
                RecipeId = 11,
                Amount = 3,
                MeasurementUnit = MeasurementUnit.Milliletres
            }

        };

            IngredientRestrictions = new HashSet<IngredientRestriction>
        {
            new IngredientRestriction
            {
                DietaryRestrictionId = 1,
                IngredientId = 2
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 2,
                IngredientId = 4
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 3,
                IngredientId = 1
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 4,
                IngredientId = 3
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 5,
                IngredientId = 5
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 1,
                IngredientId = 7
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 2,
                IngredientId = 9
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 3,
                IngredientId = 6
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 4,
                IngredientId = 8
            },
            new IngredientRestriction
            {
                DietaryRestrictionId = 5,
                IngredientId = 10
            }
        };


        }
    }
}
