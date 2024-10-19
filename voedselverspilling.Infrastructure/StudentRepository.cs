using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class StudentRepository(voedselverspillingDBContext DBContext) : IStudentRepository
{
    public IEnumerable<Student> GetAll()
    {
        return DBContext.Students;
    }

    public IQueryable<Student> GetAllAsync()
    {
        return DBContext.Students.AsQueryable();
    }

    public Student GetById(int id)
    {
        return DBContext.Students.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        return await DBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Student> AddAsync(Student item)
    {
        var result = await DBContext.Students.AddAsync(item);
        await DBContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void RemoveAsync(Student item)
    {
        DBContext.Students.Remove(item);
        await DBContext.SaveChangesAsync();
    }

    public async Task<Student> UpdateAsync(Student item)
    {
        var StudentUpdate = await DBContext.Students.FirstOrDefaultAsync(m => m.Id == item.Id);
        try
        {
            StudentUpdate.Name = item.Name;
            StudentUpdate.City = item.City;
            StudentUpdate.Email = item.Email;
            StudentUpdate.Phone = item.Phone;
            StudentUpdate.Mature = item.Mature;
            StudentUpdate.Number = item.Number;
            StudentUpdate.Birthday = item.Birthday;
            StudentUpdate.Password = item.Password;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        await DBContext.SaveChangesAsync();
        return StudentUpdate ?? null;
    }

    public IEnumerable<Student> GetAllByMature(bool mature)
    {
        return DBContext.Students.Where(x => x.Mature == mature);
    }
}

}
