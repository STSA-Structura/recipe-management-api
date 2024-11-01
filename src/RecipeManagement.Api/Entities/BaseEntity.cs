using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Api.Entities;

public class BaseEntity<T>
{
    [Key]
    public T Id { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
