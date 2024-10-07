using voedselverspilling.Domain.Models;

namespace voedselverspilling.DomainServices {

public interface ICanteenRepository : IRepository<Canteen>
{
    public IEnumerable<Canteen> GetAllByCity(string city);
    public IEnumerable<Canteen> GetAllByHotmeal(bool hotmeals);
}

}
