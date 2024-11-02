using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Api.Dtos.Recipes;
using RecipeManagement.Api.Services.Interfaces;

namespace RecipeManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService _recipeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RecipeDto>>> GetAllRecipes()
    {
        var recipes = await _recipeService.GetAllRecipesAsync();

        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeDto>> GetRecipeById(Guid id)
    {
        var recipe = await _recipeService.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeDto>> AddRecipe(RecipeCreateDto recipeDto)
    {
        var recipe = await _recipeService.AddRecipeAsync(recipeDto);

        return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRecipe(Guid id, RecipeUpdateDto updatedRecipeDto)
    {
        try
        {
            await _recipeService.UpdateRecipeAsync(id, updatedRecipeDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRecipe(Guid id)
    {
        try
        {
            await _recipeService.DeleteRecipeAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

}
