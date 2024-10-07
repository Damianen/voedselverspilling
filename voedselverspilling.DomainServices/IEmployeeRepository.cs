using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface IEmployeeRepository : IRepository<Employee>
{
    public IEnumerable<Employee> GetAllByCanteenId(int id);
    public Employee GetByNumber(int number);
}

}
