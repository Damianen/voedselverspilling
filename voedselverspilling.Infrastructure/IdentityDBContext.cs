using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.Infrastructure
{

public class IdentityDBContext : IdentityDbContext<User>
{
    public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var student = new IdentityRole("student");
        student.NormalizedName = "student";

        var employee = new IdentityRole("employee");
        employee.NormalizedName = "employee";

        builder.Entity<IdentityRole>().HasData(student, employee);
    }
}

}
