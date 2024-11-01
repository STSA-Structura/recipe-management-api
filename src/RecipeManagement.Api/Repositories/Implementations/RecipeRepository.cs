using RecipeManagement.Api.Entities.Recipes;
using RecipeManagement.Api.Repositories.Interfaces;

namespace RecipeManagement.Api.Repositories.Implementations;

public class RecipeRepository : IRecipeRepository
{
    private readonly List<Recipe> _recipes = new();

    public Task<List<Recipe>> GetAllRecipesAsync()
    {
        return Task.FromResult(_recipes);
    }

    public Task<Recipe?> GetRecipeByIdAsync(Guid id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(recipe);
    }

    public Task AddRecipeAsync(Recipe recipe)
    {
        recipe.Id = Guid.NewGuid();
        _recipes.Add(recipe);

        return Task.CompletedTask;
    }

    public Task UpdateRecipeAsync(Recipe updatedRecipe)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == updatedRecipe.Id);
        if (recipe != null)
        {
            recipe.Name = updatedRecipe.Name;
            recipe.Description = updatedRecipe.Description;
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.DifficultyLevel = updatedRecipe.DifficultyLevel;
            recipe.UpdatedAt = DateTime.UtcNow;
        }
        return Task.CompletedTask;
    }

    public Task DeleteRecipeAsync(Guid id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == id);
        if (recipe != null)
        {
            _recipes.Remove(recipe);
        }
        return Task.CompletedTask;
    }

}
