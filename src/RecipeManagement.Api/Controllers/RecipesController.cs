using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Api.Dtos.Recipes;
using RecipeManagement.Api.Entities.Recipes;
using RecipeManagement.Api.Repositories.Implementations;
using RecipeManagement.Api.Repositories.Interfaces;

namespace RecipeManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeRepository _recipeRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Recipe>>> GetAllRecipes()
    {
        var recipes = await _recipeRepository.GetAllRecipesAsync();

        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipeById(Guid id)
    {
        var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> AddRecipe(RecipeCreateDto recipeDto)
    {
        var recipe = new Recipe
        {
            Name = recipeDto.Name,
            Description = recipeDto.Description,
            Ingredients = recipeDto.Ingredients,
            DifficultyLevel = recipeDto.DifficultyLevel,
            CreatedAt = DateTime.UtcNow
        };

        await _recipeRepository.AddRecipeAsync(recipe);

        return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRecipe(Guid id, RecipeCreateDto updatedRecipeDto)
    {
        var existingRecipe = await _recipeRepository.GetRecipeByIdAsync(id);
        if (existingRecipe == null)
        {
            return NotFound();
        }

        existingRecipe.Name = updatedRecipeDto.Name;
        existingRecipe.Description = updatedRecipeDto.Description;
        existingRecipe.Ingredients = updatedRecipeDto.Ingredients;
        existingRecipe.DifficultyLevel = updatedRecipeDto.DifficultyLevel;
        existingRecipe.UpdatedAt = DateTime.UtcNow;

        await _recipeRepository.UpdateRecipeAsync(existingRecipe);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRecipe(Guid id)
    {
        var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }

        await _recipeRepository.DeleteRecipeAsync(id);
        return NoContent();
    }

}
