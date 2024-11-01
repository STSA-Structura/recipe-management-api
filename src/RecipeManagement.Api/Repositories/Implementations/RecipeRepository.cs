using RecipeManagement.Api.Entities.Recipes;
using RecipeManagement.Api.Repositories.Interfaces;
using System.Collections.Concurrent;

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
        recipe.CreatedAt = DateTime.UtcNow;
        _recipes[recipe.Id] = recipe;

        return Task.CompletedTask;
    }

    public Task UpdateRecipeAsync(Recipe updatedRecipe)
    {
        if (_recipes.TryGetValue(updatedRecipe.Id, out var recipe))
        {
            UpdateRecipeFields(recipe, updatedRecipe);
        }

        return Task.CompletedTask;
    }

    public Task DeleteRecipeAsync(Guid id)
    {
        _recipes.TryRemove(id, out _);

        return Task.CompletedTask;
    }

    private static void UpdateRecipeFields(Recipe original, Recipe updated)
    {
        original.Name = updated.Name;
        original.Description = updated.Description;
        original.Ingredients = updated.Ingredients;
        original.DifficultyLevel = updated.DifficultyLevel;
        original.UpdatedAt = DateTime.UtcNow;
    }
}
