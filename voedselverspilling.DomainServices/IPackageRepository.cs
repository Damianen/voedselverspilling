using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface IPackageRepository
{
    public IEnumerable<Product> GetAllByIdProducts(int id);
}

}
