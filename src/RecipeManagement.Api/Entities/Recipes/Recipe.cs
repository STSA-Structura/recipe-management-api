using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Api.Entities.Recipes;

public class Recipe : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public List<string> Ingredients { get; set; } = [];

    [Range(1, 5)]
    public int DifficultyLevel { get; set; }
}