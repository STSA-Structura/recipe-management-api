﻿using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Api.Controllers;
using RecipeManagement.Api.Models;

namespace RecipeManagement.Api.Tests;

[TestClass]
public sealed class RecipesControllerTests
{
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
        // This method is called before each test method.
        _controller = new RecipesController();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // This method is called after each test method.
    }

    private RecipesController _controller;

    [TestMethod]
    public void GetAllRecipes_ReturnsOkResult_WithListOfRecipes()
    {
        // Act
        var result = _controller.GetAllRecipes();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var recipes = okResult.Value as List<Recipe>;
        Assert.IsNotNull(recipes);
    }

    [TestMethod]
    public void GetRecipeById_ReturnsOkResult_WithRecipe()
    {
        // Arrange
        var recipe = new Recipe { Id = 1, Name = "Test Recipe", Description = "Test Description", Ingredients = new List<string> { "Ingredient1" } };
        RecipesController.Recipes.Add(recipe);

        // Act
        var result = _controller.GetRecipeById(1);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var returnedRecipe = okResult.Value as Recipe;
        Assert.IsNotNull(returnedRecipe);
        Assert.AreEqual(recipe.Id, returnedRecipe.Id);
    }

    [TestMethod]
    public void GetRecipeById_ReturnsNotFoundResult_WhenRecipeDoesNotExist()
    {
        // Act
        var result = _controller.GetRecipeById(999);

        // Assert
        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
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
        Assert.IsNotNull(createdAtActionResult);
        var returnedRecipe = createdAtActionResult.Value as Recipe;
        Assert.IsNotNull(returnedRecipe);
        Assert.AreEqual(recipe.Name, returnedRecipe.Name);
    }

    [TestMethod]
    public void UpdateRecipe_ReturnsNoContentResult_WhenRecipeExists()
    {
        // Arrange
        var recipe = new Recipe { Id = 1, Name = "Test Recipe", Description = "Test Description", Ingredients = new List<string> { "Ingredient1" } };
        RecipesController.Recipes.Add(recipe);
        var updatedRecipe = new Recipe { Name = "Updated Recipe", Description = "Updated Description", Ingredients = new List<string> { "Ingredient2" } };

        // Act
        var result = _controller.UpdateRecipe(1, updatedRecipe);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public void UpdateRecipe_ReturnsNotFoundResult_WhenRecipeDoesNotExist()
    {
        // Arrange
        var updatedRecipe = new Recipe { Name = "Updated Recipe", Description = "Updated Description", Ingredients = new List<string> { "Ingredient2" } };

        // Act
        var result = _controller.UpdateRecipe(999, updatedRecipe);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void DeleteRecipe_ReturnsNoContentResult_WhenRecipeExists()
    {
        // Arrange
        var recipe = new Recipe { Id = 1, Name = "Test Recipe", Description = "Test Description", Ingredients = new List<string> { "Ingredient1" } };
        RecipesController.Recipes.Add(recipe);

        // Act
        var result = _controller.DeleteRecipe(1);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public void DeleteRecipe_ReturnsNotFoundResult_WhenRecipeDoesNotExist()
    {
        // Act
        var result = _controller.DeleteRecipe(999);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

}