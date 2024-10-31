using System.Reflection;

namespace RecipeManagement.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPresentation(this IServiceCollection services)
    {
        _ = services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        // Register AutoMapper with MappingProfile
        _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
