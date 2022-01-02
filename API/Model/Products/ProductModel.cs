using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Persistence;

namespace API.Model.Products
{
    public class ProductModel : IProductModel
    {
        private IProductDao productDao;
        
        public ProductModel(IProductDao productDao)
        {
            this.productDao = productDao;
        }
        
        public Task<Product> CreateProductAsync(Product product)
        {
            return productDao.CreateProductAsync(product);
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            return productDao.GetProductByIdAsync(id);
        }

        public Task<IList<Product>> GetCompanyProductsAsync(int id)
        {
            return productDao.GetCompanyProductsAsync(id);
        }

        public Task<IList<Product>> GetPagedCompanyProductsAsync(int id, int size, int page)
        {
            return productDao.GetPagedCompanyProductsAsync(id, size, page);
        }
    }
}