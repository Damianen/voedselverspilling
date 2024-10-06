namespace voedselverspilling.DomainServices {

public interface IRepository<T>
{
    public IEnumerable<T> getAll();
    public IQueryable<T> GetAllAsync();

    public T GetById(int id);
    public Task<T> GetByIdAsync(int id);

    public Task<T> AddAsync(T item);
    public Task<T> RemoveAsync(T item);
    public Task<T> UpdateAsync(T item);
}

}
