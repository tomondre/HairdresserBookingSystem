using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Persistence
{
    public interface IProductDao
    {
        Task<Product> CreateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<IList<Product>> GetCompanyProductsAsync(int id);
    }
}