using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.GraphQL.Queries {

public class Queries()
{
    public IEnumerable<Package> GetPackages([Service] IPackageRepository _packageRepository) => _packageRepository.GetAllAsync();
    public async Task<Package> GetPackages([Service] IPackageRepository _packageRepository, int id) => await _packageRepository.GetByIdAsync(id);
    public IEnumerable<Product> GetProducts([Service] IProductRepository _productRepository) => _productRepository.GetAllAsync();
    public async Task<Product> GetProducts([Service] IProductRepository _productRepository, int id) => await _productRepository.GetByIdAsync(id);
}

}
