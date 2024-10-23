using Microsoft.AspNetCore.Identity;

namespace voedselverspilling.Domain.Models
{

public class User : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int? Number { get; set; }
    public int? CanteenId { get; set; }
    public DateTime Birthday { get; set; }
}

}
