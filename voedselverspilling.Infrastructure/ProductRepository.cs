using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace voedselverspilling.Infrastructure {

public class ProductRepository(voedselverspillingDBContext DBContext) : IProductRepository
{
    public IEnumerable<Product> GetAll()
    {
        return DBContext.Products;
    }

    public IQueryable<Product> GetAllAsync()
    {
        return DBContext.Products.AsQueryable();
    }

    public Product GetById(int id)
    {
        return DBContext.Products.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await DBContext.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> AddAsync(Product item)
    {
        var result = await DBContext.Products.AddAsync(item);
        await DBContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void RemoveAsync(Product item)
    {
        DBContext.Products.Remove(item);
        await DBContext.SaveChangesAsync();
    }

    public async Task<Product> UpdateAsync(Product item)
    {
        var ProductUpdate = await DBContext.Products.FirstOrDefaultAsync(m => m.Id == item.Id);
        try
        {
            ProductUpdate.Name = item.Name;
            ProductUpdate.Alcoholic = item.Alcoholic;
            ProductUpdate.Ingredients = item.Ingredients;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        await DBContext.SaveChangesAsync();
        return ProductUpdate ?? null;
    }

    public IEnumerable<Product> GetAllByAlcoholic(bool alcoholic)
    {
        return DBContext.Products.Where(x => x.Alcoholic == alcoholic);
    }
}

}
