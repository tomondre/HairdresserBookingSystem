
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Client.Data.Companies
{
    public class CompanyService : ICompanyService
    {
        private HttpClient client;

        public CompanyService(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{Helper.url}/companies");
            Helper.CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<Company>(readAsStringAsync);
            return deserialize;
        }
    }
}