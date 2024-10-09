using voedselverspilling.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class voedselverspillingDBContext : DbContext {

    public voedselverspillingDBContext(DbContextOptions<voedselverspillingDBContext> options) : base(options)
    {
    }

    public DbSet<Canteen> Canteens { get; set; } = null!;

    public DbSet<Package> Packages { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}

}
