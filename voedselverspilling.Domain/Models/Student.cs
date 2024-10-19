using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Student
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public DateTime? Birthday { get; set; }

    [Required]
    public int? Number { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required]
    public bool? Mature { get; set; }

    [Required]
    public string? Password { get; set; }
}

}

