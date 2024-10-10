using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public enum MealTypes
{
    Bread,
    HotMeal,
    Drink
}

public class Package
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public List<Product>? Products { get; set; }

    [Required]
    public Canteen? Canteen { get; set; }

    [Required]
    public DateTime? Pickup { get; set; }

    [Required]
    public bool? Mature { get; set; }

    [Required]
    public float? Price { get; set; }

    [Required]
    public MealTypes? MealType { get; set; }
}

}
