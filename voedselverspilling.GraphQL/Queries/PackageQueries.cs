using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.GraphQL.Queries {

public class PackageQueries()
{
    public IEnumerable<Package> GetStudentClasses([Service] IPackageRepository _packageRepository) => _packageRepository.GetAllAsync();
    public async Task<Package> GetStudentClasses([Service] IPackageRepository _packageRepository, int id) => await _packageRepository.GetByIdAsync(id);
}

}
