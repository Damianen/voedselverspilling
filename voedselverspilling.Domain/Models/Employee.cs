using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Employee
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int? Number { get; set; }

    [Required]
    public Canteen? Canteen { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}

}
