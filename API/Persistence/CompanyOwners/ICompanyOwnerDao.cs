using System.Threading.Tasks;
using Shared.Models;

namespace API.Persistence.CompanyOwners
{
    public interface ICompanyOwnerDao
    {
        Task<CompanyOwner> CreateCompanyOwnerAsync(CompanyOwner companyOwner);
        Task<Company> GetCompanyByCompanyOwnerIdAsync(int id);
    }
}