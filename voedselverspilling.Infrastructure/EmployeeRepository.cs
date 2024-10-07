using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class EmployeeRepository(voedselverspillingDBContext DBContext) : IEmployeeRepository
{
    public IEnumerable<Employee> GetAll()
    {
        return DBContext.Employees;
    }

    public IQueryable<Employee> GetAllAsync()
    {
        return DBContext.Employees.AsQueryable();
    }

    public Employee GetById(int id)
    {
        return DBContext.Employees.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await DBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Employee> AddAsync(Employee item)
    {
        var result = await DBContext.Employees.AddAsync(item);
        await DBContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void RemoveAsync(Employee item)
    {
        DBContext.Employees.Remove(item);
        await DBContext.SaveChangesAsync();
    }

    public async Task<Employee> UpdateAsync(Employee item)
    {
        var EmployeeUpdate = await DBContext.Employees.FirstOrDefaultAsync(m => m.Id == item.Id);
        try
        {
            EmployeeUpdate.Name = item.Name;
            EmployeeUpdate.Number = item.Number;
            EmployeeUpdate.Location = item.Location;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        await DBContext.SaveChangesAsync();
        return EmployeeUpdate ?? null;
    }

    public IEnumerable<Employee> GetAllByCanteenId(int id)
    {
        return DBContext.Employees.Where(x => x.Location == DBContext.Canteens.FirstOrDefault(x => x.Id == id));
    }

    public Employee GetByNumber(int number)
    {
        return DBContext.Employees.FirstOrDefault(x => x.Number == number);
    }
}

}
