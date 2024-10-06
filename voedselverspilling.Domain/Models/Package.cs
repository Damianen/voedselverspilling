namespace voedselverspilling.Domain.Models {

public enum MealTypes
{
    Bread,
    HotMeal,
    Drink
}

public class Package
{
    public int? Id { get; init; }
    public string? Name { get; set; }
    public List<Product>? Products { get; set; }
    public string? City { get; set; }
    public DateTime? Pickup { get; set; }
    public bool? Mature { get; set; }
    public float? Price { get; set; }
    public MealTypes? MealType { get; set; }
    public Student? Reservor { get; set; }
}

}
