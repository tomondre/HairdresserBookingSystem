using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Client.Models;
using Shared.Models;

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
            var httpResponseMessage = await client.GetAsync($"{Helper.url}/companies/{id}/products");
            await Helper.CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<IList<Product>>(readAsStringAsync);
            return new ProductList
            {
                Products = deserialize
            };
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var serialize = Helper.Serialize(product);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync = await client.PostAsync($"{Helper.url}/products", stringContent);
            await Helper.CheckException(postAsync);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<Product>(readAsStringAsync);
            return deserialize;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var serialize = Helper.Serialize(product);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PatchAsync($"{Helper.url}/products/{product.Id}", stringContent);
            await Helper.CheckException(httpResponseMessage);
            var deserialize = await Helper.Deserialize<Product>(httpResponseMessage);
            return deserialize;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var httpResponseMessage = await client.DeleteAsync($"{Helper.url}/products/{productId}");
            await Helper.CheckException(httpResponseMessage);
            var deserialize = await Helper.Deserialize<Product>(httpResponseMessage);
            return deserialize;
        }
    }
}