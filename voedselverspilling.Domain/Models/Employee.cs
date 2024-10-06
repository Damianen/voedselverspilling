namespace voedselverspilling.Domain.Models {

public class Employee
{
    public int? Id { get; init; }
    public string? Name { get; set; }
    public int? Number { get; set; }
    public Canteen? Location { get; set; }
}

}
