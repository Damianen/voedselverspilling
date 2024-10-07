using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface IStudentRepository : IRepository<Student>
{
    public IEnumerable<Student> GetAllByMature(bool mature);
}

}
