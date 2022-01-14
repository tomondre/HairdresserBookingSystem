using System.Threading.Tasks;
using API.Persistence.CompanyOwners;
using Shared.Models;

namespace API.Model.CompanyOwners
{
    public class CompanyOwnerModel : ICompanyOwnerModel
    {
        private ICompanyOwnerDao dao;

        public CompanyOwnerModel(ICompanyOwnerDao dao)
        {
            this.dao = dao;
        }
        
        public Task<CompanyOwner> CreateCompanyOwnerAsync(CompanyOwner companyOwner)
        {
            return dao.CreateCompanyOwnerAsync(companyOwner);
        }
    }
}