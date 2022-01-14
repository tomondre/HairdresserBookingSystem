using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;

namespace Client.Data.Customers
{
    public class CustomerService : ICustomerService
    {
        private HttpClient client;

        public CustomerService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var serialize = Helper.Serialize(customer);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync = await client.PostAsync($"{Helper.url}/customers", stringContent);
            await Helper.CheckException(postAsync);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<Customer>(readAsStringAsync);
            return deserialize;
        }
    }
}