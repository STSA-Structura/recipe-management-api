namespace RecipeManagement.Api.Extensions;

public static class HttpPipelineConfigurationExtensions
{
    public static void UseConfiguredHttpPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();

        _ = app.MapControllers();
    }
}
