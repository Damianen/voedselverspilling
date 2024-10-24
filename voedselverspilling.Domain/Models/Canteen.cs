using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Canteen
{
    [Key]
    public int Id { get; init; }

    [Required]
    public string City { get; init; } = "";

    [Required]
    public string Location { get; init; } = "";

    [Required]
    public bool HotMeals { get; set; }
}

}
