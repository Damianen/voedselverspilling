using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class ResorvationRepository(voedselverspillingDBContext DBContext) : IResorvationRepository
{
    public IEnumerable<Resorvation> GetAll()
    {
        return DBContext.Resorvations;
    }

    public IQueryable<Resorvation> GetAllAsync()
    {
        return DBContext.Resorvations.AsQueryable();
    }

    public Resorvation GetById(int id)
    {
        return DBContext.Resorvations.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Resorvation> GetByIdAsync(int id)
    {
        return await DBContext.Resorvations.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Resorvation> AddAsync(Resorvation item)
    {
        var result = await DBContext.Resorvations.AddAsync(item);
        await DBContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void RemoveAsync(Resorvation item)
    {
        DBContext.Resorvations.Remove(item);
        await DBContext.SaveChangesAsync();
    }

    public async Task<Resorvation> UpdateAsync(Resorvation item)
    {
        var ResorvationUpdate = await DBContext.Resorvations.FirstOrDefaultAsync(m => m.Id == item.Id);
        try
        {
            ResorvationUpdate.PickedUp = item.PickedUp;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        await DBContext.SaveChangesAsync();
        return ResorvationUpdate ?? null;
    }

    public Resorvation GetByStudentId(int studentId)
    {
        return DBContext.Resorvations.FirstOrDefault(x => x.Student.Id == studentId);
    }

    public Resorvation GetByPackageId(int packageId)
    {
        return DBContext.Resorvations.FirstOrDefault(x => x.Package.Id == packageId);
    }

}

}
