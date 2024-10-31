namespace RecipeManagement.Api.Dtos.Recipes;

public class RecipeCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<string> Ingredients { get; set; } = [];

    public int DifficultyLevel { get; set; }
}