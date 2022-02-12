using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Model.Products
{
    public interface IProductModel
    {
        
        Task<Product> CreateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<IList<Product>> GetCompanyProductsAsync(int id);
        Task<IList<Product>> GetPagedCompanyProductsAsync(int id, int size, int page);
        Task<Product> DeleteProductAsync(int id);
    }
}