using AutoMapper;
using RecipeManagement.Api.Dtos.Recipes;
using RecipeManagement.Api.Entities.Recipes;

namespace RecipeManagement.Api.Profiles;

public class RecipesMappingProfile : Profile
{
    public RecipesMappingProfile()
    {
        CreateMap<Recipe, RecipeDto>();
        CreateMap<RecipeCreateDto, Recipe>();
        CreateMap<RecipeUpdateDto, Recipe>();
    }
}