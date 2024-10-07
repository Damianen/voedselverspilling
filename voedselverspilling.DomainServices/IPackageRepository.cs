using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface IPackageRepository : IRepository<Package>
{
    public IEnumerable<Product> GetAllByIdProducts(int id);
}

}