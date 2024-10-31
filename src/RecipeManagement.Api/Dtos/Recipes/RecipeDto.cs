namespace RecipeManagement.Api.Dtos.Recipes;

public class RecipeDto : RecipeBaseDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}