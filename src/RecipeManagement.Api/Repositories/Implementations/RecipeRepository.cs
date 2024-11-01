using System.Collections.Concurrent;
using RecipeManagement.Api.Entities.Recipes;
using RecipeManagement.Api.Repositories.Interfaces;

namespace RecipeManagement.Api.Repositories.Implementations;

public class RecipeRepository : IRecipeRepository
{
    private readonly ConcurrentDictionary<Guid, Recipe> _recipes = new();

    public Task<List<Recipe>> GetAllRecipesAsync()
    {
        var recipes = _recipes.Values.ToList();
        return Task.FromResult(recipes);
    }

    public Task<Recipe?> GetRecipeByIdAsync(Guid id)
    {
        _recipes.TryGetValue(id, out var recipe);
        return Task.FromResult(recipe);
    }

    public Task AddRecipeAsync(Recipe recipe)
    {
        recipe.Id = Guid.NewGuid();
        _recipes[recipe.Id] = recipe;
        return Task.CompletedTask;
    }

    public Task UpdateRecipeAsync(Recipe updatedRecipe)
    {
        if (_recipes.TryGetValue(updatedRecipe.Id, out var recipe))
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
        _recipes.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}
