using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface IResorvationRepository : IRepository<Resorvation>
{
    public Resorvation GetByStudentId(string studentId);
    public Resorvation GetByPackageId(int packageId);
}

}
