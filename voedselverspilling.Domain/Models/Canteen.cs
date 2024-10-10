using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Canteen
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? Location { get; set; }

    [Required]
    public bool? HotMeals { get; set; }
}

}
