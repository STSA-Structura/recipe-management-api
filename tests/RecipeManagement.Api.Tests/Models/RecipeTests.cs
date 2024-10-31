using RecipeManagement.Api.Models;
using System.Diagnostics.CodeAnalysis;

namespace RecipeManagement.Api.Tests.Models;

[TestClass]
[ExcludeFromCodeCoverage]
public class RecipeTests
{
    [TestMethod]
    public void Recipe_DefaultConstructor_InitializesProperties()
    {
        // Arrange & Act
        var recipe = new Recipe();

        // Assert
        Assert.AreEqual(0, recipe.Id);
        Assert.AreEqual(string.Empty, recipe.Name);
        Assert.AreEqual(string.Empty, recipe.Description);
        Assert.IsNotNull(recipe.Ingredients);
        Assert.AreEqual(0, recipe.Ingredients.Count);
    }

    [TestMethod]
    public void Recipe_SetAndGetProperties()
    {
        // Arrange
        var recipe = new Recipe();
        var ingredients = new List<string> { "Ingredient1", "Ingredient2" };

        // Act
        recipe.Id = 1;
        recipe.Name = "Test Recipe";
        recipe.Description = "Test Description";
        recipe.Ingredients = ingredients;

        // Assert
        Assert.AreEqual(1, recipe.Id);
        Assert.AreEqual("Test Recipe", recipe.Name);
        Assert.AreEqual("Test Description", recipe.Description);
        Assert.AreEqual(ingredients, recipe.Ingredients);
    }

    [TestMethod]
    public void Recipe_IngredientsProperty_CanAddItems()
    {
        // Arrange
        var recipe = new Recipe();

        // Act
        recipe.Ingredients.Add("Ingredient1");
        recipe.Ingredients.Add("Ingredient2");

        // Assert
        Assert.AreEqual(2, recipe.Ingredients.Count);
        Assert.AreEqual("Ingredient1", recipe.Ingredients[0]);
        Assert.AreEqual("Ingredient2", recipe.Ingredients[1]);
    }
}
