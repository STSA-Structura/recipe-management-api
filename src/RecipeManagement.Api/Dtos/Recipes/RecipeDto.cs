namespace RecipeManagement.Api.Dtos.Recipes;

public class RecipeDto : RecipeBaseDto
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}