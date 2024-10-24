using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data;

namespace voedselverspilling.Infrastructure {

public class PackageRepository(voedselverspillingDBContext DBContext) : IPackageRepository
{
    public IEnumerable<Package> GetAll()
    {
        return DBContext.Packages
            .Include(package => package.Canteen)
            .Include(package => package.Products)
            .Include(package => package.Resorvation);
    }

    public IQueryable<Package> GetAllAsync()
    {
        return DBContext.Packages.AsQueryable();
    }

    public Package GetById(int id)
    {
        return DBContext.Packages
            .Include(package => package.Canteen)
            .Include(package => package.Products)
            .Include(package => package.Resorvation)
            .FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Id not found");
    }

    public async Task<Package> GetByIdAsync(int id)
    {
        return await DBContext.Packages.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception("Id not found");
    }

    public async Task<Package> AddAsync(Package item)
    {
        var result = await DBContext.AddAsync(item);
        await DBContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void RemoveAsync(Package item)
    {
        DBContext.Packages.Remove(item);
        await DBContext.SaveChangesAsync();
    }

    public async Task<Package> UpdateAsync(Package item)
    {
        var PackageUpdate = await DBContext.Packages.FirstOrDefaultAsync(m => m.Id == item.Id)
            ?? throw new Exception("Id not found");

        PackageUpdate.Name = item.Name;
        PackageUpdate.Canteen = item.Canteen;
        PackageUpdate.Price = item.Price;
        PackageUpdate.Mature = item.Mature;
        PackageUpdate.Pickup = item.Pickup;
        PackageUpdate.MealType = item.MealType;
        PackageUpdate.Products = item.Products;
        PackageUpdate.ImageName = item.ImageName;

        return PackageUpdate;
    }

    public IEnumerable<Product> GetAllByIdProducts(int id)
    {
        var package = DBContext.Packages.FirstOrDefault(x => x.Id == id);
        
        if (package == null) return [];

        return package.Products;
    }

    public IEnumerable<Package> GetAllWithMealType(MealTypes mealType)
    {
        return DBContext.Packages
            .Where(package => package.MealType == mealType)
            .Include(package => package.Resorvation);
    }
}

}
