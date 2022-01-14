using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Client.Models;
using Shared.Models;

namespace Client.Data
{
    public interface IProductService
    {
        Task<ProductList> GetAllCompanyProducts(int id);
        Task<Product> CreateProductAsync(Product product);
    }
}