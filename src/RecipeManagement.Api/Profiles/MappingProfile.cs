using AutoMapper;
using RecipeManagement.Api.Dtos.Recipes;
using RecipeManagement.Api.Entities.Recipes;

namespace RecipeManagement.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Recipe, RecipeDto>();
        CreateMap<RecipeCreateDto, Recipe>();
        CreateMap<RecipeUpdateDto, Recipe>();
    }
}