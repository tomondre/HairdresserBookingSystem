using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IProductService
    {
        Task<ProductList> GetAllCompanyProducts(int id);
    }
}