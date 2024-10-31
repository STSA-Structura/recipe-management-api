namespace RecipeManagement.Api.Extensions;

public static class HttpPipelineConfigurationExtensions
{
    public static void UseConfiguredHttpPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
