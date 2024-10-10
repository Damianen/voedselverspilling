using System.ComponentModel.DataAnnotations;

namespace voedselverspilling.Domain.Models {

public class Resorvation
{
    public Resorvation(Student student, Package package)
    {
        Student = student;
        Package = package;
    }


    [Key]
    public int? Id { get; init; }

    [Required]
    public Student? Student { get; init; }

    [Required]
    public Package? Package { get; init; }
}

}
