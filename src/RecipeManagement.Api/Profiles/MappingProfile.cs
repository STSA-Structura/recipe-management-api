using AutoMapper;
using RecipeManagement.Api.Dtos;
using RecipeManagement.Api.Models;

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