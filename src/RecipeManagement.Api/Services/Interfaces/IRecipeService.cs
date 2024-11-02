using RecipeManagement.Api.Dtos.Recipes;

namespace RecipeManagement.Api.Services.Interfaces;

public interface IRecipeService
{
    Task<List<RecipeDto>> GetAllRecipesAsync();

    Task<RecipeDto?> GetRecipeByIdAsync(Guid id);

    Task<RecipeDto> AddRecipeAsync(RecipeCreateDto recipeDto);

    Task UpdateRecipeAsync(Guid id, RecipeUpdateDto updatedRecipeDto);

    Task DeleteRecipeAsync(Guid id);
}
