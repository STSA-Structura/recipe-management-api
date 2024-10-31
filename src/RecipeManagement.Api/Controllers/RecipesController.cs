using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Api.Entities.Recipes;

namespace RecipeManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController(List<Recipe>? recipes = null) : ControllerBase
{
    private readonly List<Recipe> _recipes = recipes ?? [];

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        return Ok(_recipes);
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipeById(Guid id)
    {
        var recipe = _recipes.Find(r => r.Id == id);
        if (recipe == null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }

    [HttpPost]
    public ActionResult<Recipe> AddRecipe(Recipe recipe)
    {
        recipe.Id = Guid.NewGuid(); // Simple ID generation for example
        _recipes.Add(recipe);

        return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateRecipe(Guid id, Recipe updatedRecipe)
    {
        var recipe = _recipes.Find(r => r.Id == id);
        if (recipe == null)
        {
            return NotFound();
        }

        recipe.Name = updatedRecipe.Name;
        recipe.Description = updatedRecipe.Description;
        recipe.Ingredients = updatedRecipe.Ingredients;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteRecipe(Guid id)
    {
        var recipe = _recipes.Find(r => r.Id == id);
        if (recipe == null) return NotFound();

        _recipes.Remove(recipe);
        return NoContent();
    }
}
