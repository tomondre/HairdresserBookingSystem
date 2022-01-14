using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Client.Data.CompanyOwners
{
    public class CompanyOwnerService : ICompanyOwnerService
    {
        private HttpClient client;

        public CompanyOwnerService(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<Company> GetCompanyByCompanyOwnerIdAsync(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{Helper.url}/companyOwners/{id}/company");
            await Helper.CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<Company>(readAsStringAsync);
            return deserialize;
        }
    }
}