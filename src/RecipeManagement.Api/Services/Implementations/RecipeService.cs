using AutoMapper;
using RecipeManagement.Api.Dtos.Recipes;
using RecipeManagement.Api.Entities.Recipes;
using RecipeManagement.Api.Repositories.Interfaces;
using RecipeManagement.Api.Services.Interfaces;

namespace RecipeManagement.Api.Services.Implementations;

public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : IRecipeService
{
    public async Task<List<RecipeDto>> GetAllRecipesAsync()
    {
        var recipes = await recipeRepository.GetAllRecipesAsync();

        return mapper.Map<List<RecipeDto>>(recipes);
    }

    public async Task<RecipeDto?> GetRecipeByIdAsync(Guid id)
    {
        var recipe = await recipeRepository.GetRecipeByIdAsync(id);

        return mapper.Map<RecipeDto?>(recipe);
    }

    public async Task<RecipeDto> AddRecipeAsync(RecipeCreateDto recipeDto)
    {
        var recipe = mapper.Map<Recipe>(recipeDto);
        await recipeRepository.AddRecipeAsync(recipe);

        return mapper.Map<RecipeDto>(recipe);
    }

    public async Task UpdateRecipeAsync(Guid id, RecipeUpdateDto updatedRecipeDto)
    {
        var existingRecipe = await recipeRepository.GetRecipeByIdAsync(id) ?? throw new Exception("Recipe not found");
        mapper.Map(updatedRecipeDto, existingRecipe);

        await recipeRepository.UpdateRecipeAsync(existingRecipe);
    }

    public async Task DeleteRecipeAsync(Guid id)
    {
        var recipe = await recipeRepository.GetRecipeByIdAsync(id) ?? throw new Exception("Recipe not found");

        await recipeRepository.DeleteRecipeAsync(id);
    }
}