using RecipeManagement.Api.Profiles;

namespace RecipeManagement.Api.Extensions;

public static class ServiceCollectionExtension
{

    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Register AutoMapper with MappingProfile
        services.AddAutoMapper(typeof(RecipesMappingProfile));
    }

}
