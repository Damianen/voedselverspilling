using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class CanteenRepository(voedselverspillingDBContext DBContext) : ICanteenRepository
{
    public IEnumerable<Canteen> GetAll()
    {
        return DBContext.Canteens;
    }

    public IQueryable<Canteen> GetAllAsync()
    {
        return DBContext.Canteens.AsQueryable();
    }

    public Canteen GetById(int id)
    {
        return DBContext.Canteens.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Canteen> GetByIdAsync(int id)
    {
        return await DBContext.Canteens.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Canteen> AddAsync(Canteen item)
    {
        var result = await DBContext.Canteens.AddAsync(item);
        await DBContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void RemoveAsync(Canteen item)
    {
        DBContext.Canteens.Remove(item);
        await DBContext.SaveChangesAsync();
    }

    public async Task<Canteen> UpdateAsync(Canteen item)
    {
        var CanteenUpdate = await DBContext.Canteens.FirstOrDefaultAsync(m => m.Id == item.Id);
        try
        {
            CanteenUpdate.City = item.City;
            CanteenUpdate.HotMeals = item.HotMeals;
            CanteenUpdate.Location = item.Location;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        await DBContext.SaveChangesAsync();
        return CanteenUpdate ?? null;
    }

    public IEnumerable<Canteen> GetAllByCity(string city)
    {
        return DBContext.Canteens.Where(x => x.City == city);
    }

    public IEnumerable<Canteen> GetAllByHotmeal(bool hotmeals)
    {
        return DBContext.Canteens.Where(x => x.HotMeals == hotmeals);
    }
}

}