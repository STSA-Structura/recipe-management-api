﻿using RecipeManagement.Api.Entities.Recipes;

namespace RecipeManagement.Api.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<List<Recipe>> GetAllRecipesAsync();

    Task<Recipe?> GetRecipeByIdAsync(Guid id);

    Task AddRecipeAsync(Recipe recipe);

    Task UpdateRecipeAsync(Recipe recipe);

    Task DeleteRecipeAsync(Guid id);
}
