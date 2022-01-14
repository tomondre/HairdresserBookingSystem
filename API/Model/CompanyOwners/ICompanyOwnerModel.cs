using System.Threading.Tasks;
using Shared.Models;

namespace API.Model.CompanyOwners
{
    public interface ICompanyOwnerModel
    {
        Task<CompanyOwner> CreateCompanyOwnerAsync(CompanyOwner companyOwner);
    }
}