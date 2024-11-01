using RecipeManagement.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseConfiguredHttpPipeline();

app.Run();
