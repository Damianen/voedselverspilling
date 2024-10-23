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
        return DBContext.Packages;
    }

    public IQueryable<Package> GetAllAsync()
    {
        return DBContext.Packages.AsQueryable();
    }

    public Package GetById(int id)
    {
        return DBContext.Packages.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Package> GetByIdAsync(int id)
    {
        return await DBContext.Packages.FirstOrDefaultAsync(x => x.Id == id);
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
        var PackageUpdate = await DBContext.Packages.FirstOrDefaultAsync(m => m.Id == item.Id);
        try
        {
            PackageUpdate.Name = item.Name;
            PackageUpdate.Canteen = item.Canteen;
            PackageUpdate.Price = item.Price;
            PackageUpdate.Mature = item.Mature;
            PackageUpdate.Pickup = item.Pickup;
            PackageUpdate.MealType = item.MealType;
            PackageUpdate.Products = item.Products;
            PackageUpdate.ImageName = item.ImageName;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return PackageUpdate ?? null;
    }

    public IEnumerable<Product> GetAllByIdProducts(int id)
    {
        return DBContext.Packages.FirstOrDefault(x => x.Id == id).Products;
    }

    public IEnumerable<Package> GetAllWithMealType(MealTypes mealType)
    {
        return from package in DBContext.Packages
               where mealType == package.MealType
               select package;
    }
}

}
