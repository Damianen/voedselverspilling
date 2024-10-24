using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace voedselverspilling.Domain.Models {

public enum ResorvationStatus 
{
    PickedUp,
    Reserved,
    Available,
    NotPickedUp,
}

public class Resorvation
{
    [Key]
    public int? Id { get; init; }

    [Required]
    public string StudentId { get; init; } = "";

    [Required]
    public int PackageId { get; init; }

    [Required]
    [ForeignKey("PackageId")]
    public Package Package { get; init; } = new Package();

    [Required]
    public ResorvationStatus Status { get; set; }
}

}
