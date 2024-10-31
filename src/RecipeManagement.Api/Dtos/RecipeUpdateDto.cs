namespace RecipeManagement.Api.Dtos;

public class RecipeUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<string> Ingredients { get; set; } = [];

    public int DifficultyLevel { get; set; }
}