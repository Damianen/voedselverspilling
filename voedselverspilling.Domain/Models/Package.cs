using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace voedselverspilling.Domain.Models {

public enum MealTypes
{
    Breakfast,
    Lunch,
    Dinner,
    Snack
}

public class Package
{
    [Key]
    public int Id { get; init; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public List<Product> Products { get; set; } = [];

    [Required]
    public Canteen Canteen { get; set; } = new Canteen();
    
    [Required]
    public DateTime Pickup { get; set; }

    [Required]
    public bool Mature { get; set; }

    [Required]
    public float Price { get; set; }

    [Required]
    public MealTypes MealType { get; set; }

    [Required]
    public string ImageName { get; set; } = "";

    
    public Resorvation? Resorvation { get; set; }
}

}
