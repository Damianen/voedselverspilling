using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface IProductRepository : IRepository<Product>
{
    public IEnumerable<Product> GetAllByAlcoholic(bool alcoholic);
}

}
