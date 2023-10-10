using UnitTestingA1Base.Data;
using UnitTestingA1Base.Models;

namespace RecipeUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private BusinessLogicLayer _initializeBusinessLogic()
        {
            return new BusinessLogicLayer(new AppStorage());
        }
        [TestMethod]
        public void GetRecipesByIngredient_ValidId_ReturnsRecipesWithIngredient()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 6;
            int recipeCount = 2;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, null);

            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidName_ReturnsRecipesWithIngredient()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Spaghetti";
            int recipeCount = 2;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(null, ingredientName);

            Assert.AreEqual(recipeCount, recipes.Count);

        }

        [TestMethod]
        public void GetRecipesByIngredient_InvalidId_ReturnsNull()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 100;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, null);

            Assert.AreEqual(0, recipes.Count);

        }

        [TestMethod]
        public void GetRecipesByDietaryRestriction_ValidId_ReturnsRecipesWithRestriction()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int restrictionId = 2;  // This should be a valid restriction id in your storage.
            int expectedRecipeCount = 3;  // Expected number of recipes with the given restriction.

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByDietaryRestriction(restrictionId, null);

            // assert
            Assert.AreEqual(expectedRecipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietaryRestriction_InvalidId_ReturnsEmpty()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int restrictionId = 100;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByDietaryRestriction(restrictionId, null);

            // assert
            Assert.AreEqual(0, recipes.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteIngredient_UsedInMultipleRecipes_ThrowsException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 1;  // ID of an ingredient used in multiple recipes.

            // act
            bll.DeleteIngredient(ingredientId, null);
        }
        [TestMethod]
        public void DeleteIngredient_ValidId_RemovesIngredient()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 3;  // ID of an ingredient used in a single recipe.

            // act
            bll.DeleteIngredient(ingredientId, null);

            // assert
            bool ingredientExists = bll.CheckIfIngredientExists(ingredientId);  // This method needs to be added to the BusinessLogicLayer.
            Assert.IsFalse(ingredientExists);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteIngredient_InvalidId_ThrowsException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 100;

            // act
            bll.DeleteIngredient(ingredientId, null);
        }


    }
}