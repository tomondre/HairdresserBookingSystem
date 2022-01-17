using System.Threading.Tasks;
using Shared.Models;

namespace Client.Data.CompanyOwners
{
    public interface ICompanyOwnerService
    {
        Task<Company> GetCompanyByCompanyOwnerIdAsync(int id);
        Task<CompanyOwner> CreateCompanyOwnerAsync(CompanyOwner newCompanyOwner);
    }
}