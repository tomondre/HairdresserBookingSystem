using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;
using Client.Models;

namespace Client.Data
{
    public class ProductService : IProductService

    {
        private HttpClient client;

        public ProductService(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<ProductList> GetAllCompanyProducts(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{Global.url}/companies/{id}/products");
            Global.CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = Global.Deserialize<IList<Product>>(readAsStringAsync);
            return new ProductList
            {
                Products = deserialize
            };
        }
        
        
    }
}