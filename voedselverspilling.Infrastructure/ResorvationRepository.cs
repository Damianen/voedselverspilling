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

    public Task<Resorvation> UpdateAsync(Resorvation item)
    {
        throw new Exception();
    }

    public Resorvation GetByStudentId(int studentId)
    {
        return DBContext.Resorvations.FirstOrDefault(x => x.Student.Id == studentId);
    }

    public Resorvation GetByPackageId(int packageId)
    {
        return DBContext.Resorvations.FirstOrDefault(x => x.Package.Id == packageId);
    }

    public async Task<Resorvation> AddByIdsAsync(int studentId, int packageId)
    {
        var resorvation = new Resorvation(
                DBContext.Students.FirstOrDefault(x => x.Id == studentId),
                DBContext.Packages.FirstOrDefault(x => x.Id == packageId)
            );
        var result = await DBContext.Resorvations.AddAsync(resorvation);
        return result.Entity;
    }
 }

}
