using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Resorvation
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public Student? Student { get; init; }

    [Required]
    public Package? Package { get; init; }
}

}
