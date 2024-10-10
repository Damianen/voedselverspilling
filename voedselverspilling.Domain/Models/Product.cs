using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Product
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public bool? Alcoholic { get; set; }

    [Required]
    public string? Picture { get; set; }
}

}
