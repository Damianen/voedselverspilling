using voedselverspilling.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class voedselverspillingDBContext : DbContext {

    public DbSet<Canteen> Canteens { get; set; } = null!;

    public DbSet<Package> Packages { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=localhost;Database=voedselverspilling;Port=5432;User Id=postgres;Password=password;");
    }
}

}
