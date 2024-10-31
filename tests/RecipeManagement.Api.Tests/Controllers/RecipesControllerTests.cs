using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Api.Controllers;
using RecipeManagement.Api.Models;
using System.Diagnostics.CodeAnalysis;

namespace RecipeManagement.Api.Tests.Controllers;

[TestClass]
[ExcludeFromCodeCoverage]
public sealed class RecipesControllerTests
{
    private RecipesController _controller = default!;
    private List<Recipe> _recipes = [];

    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        // This method is called once for the test assembly, before any tests are run.
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        // This method is called once for the test assembly, after all tests are run.
    }

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        // This method is called once for the test class, before any tests of the class are run.
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // This method is called once for the test class, after all tests of the class are run.
    }

    [TestInitialize]
    public void TestInit()
    {
        _recipes = [];
        _controller = new RecipesController(_recipes);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // This method is called after each test method.
    }

    [TestMethod]
    public void GetAllRecipes_ReturnsOkResult_WithListOfRecipes()
    {
        // Act
        var result = _controller.GetAllRecipes();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult, "Expected OkObjectResult");
        var recipes = okResult.Value as List<Recipe>;
        Assert.IsNotNull(recipes, "Expected a list of recipes");
        Assert.AreEqual(0, recipes.Count, "Expected the list to be empty initially");
    }

    [TestMethod]
    public void GetRecipeById_ReturnsOkResult_WithRecipe()
    {
        // Arrange
        var recipe = new Recipe { Id = 1, Name = "Test Recipe", Description = "Test Description", Ingredients = new List<string> { "Ingredient1" } };
        _recipes.Add(recipe);

        // Act
        var result = _controller.GetRecipeById(1);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult, "Expected OkObjectResult");
        var returnedRecipe = okResult.Value as Recipe;
        Assert.IsNotNull(returnedRecipe, "Expected a recipe object");
        Assert.AreEqual(recipe.Id, returnedRecipe.Id, "Expected recipe IDs to match");
    }

    [TestMethod]
    public void GetRecipeById_ReturnsNotFoundResult_WhenRecipeDoesNotExist()
    {
        // Act
        var result = _controller.GetRecipeById(999);

        // Assert
        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Expected NotFoundResult for non-existing recipe ID");
    }

    [TestMethod]
    public void AddRecipe_ReturnsCreatedAtActionResult_WithRecipe()
    {
        // Arrange
        var recipe = new Recipe { Name = "New Recipe", Description = "New Description", Ingredients = new List<string> { "Ingredient1" } };

        // Act
        var result = _controller.AddRecipe(recipe);

        // Assert
        var createdAtActionResult = result.Result as CreatedAtActionResult;
        Assert.IsNotNull(createdAtActionResult, "Expected CreatedAtActionResult");
        var returnedRecipe = createdAtActionResult.Value as Recipe;
        Assert.IsNotNull(returnedRecipe, "Expected a recipe object");
        Assert.AreEqual(recipe.Name, returnedRecipe.Name, "Expected recipe names to match");
        Assert.AreEqual(1, returnedRecipe.Id, "Expected the new recipe to have ID 1");
    }

    [TestMethod]
    public void UpdateRecipe_ReturnsNoContentResult_WhenRecipeExists()
    {
        // Arrange
        var recipe = new Recipe { Id = 1, Name = "Test Recipe", Description = "Test Description", Ingredients = new List<string> { "Ingredient1" } };
        _recipes.Add(recipe);
        var updatedRecipe = new Recipe { Name = "Updated Recipe", Description = "Updated Description", Ingredients = new List<string> { "Ingredient2" } };

        // Act
        var result = _controller.UpdateRecipe(1, updatedRecipe);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NoContentResult), "Expected NoContentResult for a successful update");
        Assert.AreEqual("Updated Recipe", _recipes[0].Name, "Expected recipe name to be updated");
        Assert.AreEqual("Updated Description", _recipes[0].Description, "Expected recipe description to be updated");
    }

    [TestMethod]
    public void UpdateRecipe_ReturnsNotFoundResult_WhenRecipeDoesNotExist()
    {
        // Arrange
        var updatedRecipe = new Recipe { Name = "Updated Recipe", Description = "Updated Description", Ingredients = new List<string> { "Ingredient2" } };

        // Act
        var result = _controller.UpdateRecipe(999, updatedRecipe);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Expected NotFoundResult for non-existing recipe ID");
    }

    [TestMethod]
    public void DeleteRecipe_ReturnsNoContentResult_WhenRecipeExists()
    {
        // Arrange
        var recipe = new Recipe { Id = 1, Name = "Test Recipe", Description = "Test Description", Ingredients = new List<string> { "Ingredient1" } };
        _recipes.Add(recipe);

        // Act
        var result = _controller.DeleteRecipe(1);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NoContentResult), "Expected NoContentResult for a successful deletion");
        Assert.AreEqual(0, _recipes.Count, "Expected the recipe list to be empty after deletion");
    }

    [TestMethod]
    public void DeleteRecipe_ReturnsNotFoundResult_WhenRecipeDoesNotExist()
    {
        // Act
        var result = _controller.DeleteRecipe(999);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Expected NotFoundResult for non-existing recipe ID");
    }

}
