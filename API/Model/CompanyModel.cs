using System.Threading.Tasks;
using API.Models;
using API.Persistence;

namespace API.Model
{
    public class CompanyModel : ICompanyModel
    {
        private ICompanyDao companyDao;
        
        public CompanyModel(ICompanyDao companyDao)
        {
            this.companyDao = companyDao;
        }
        
        public Task<Company> CreateCompanyAsync(Company company)
        {
            return companyDao.CreateCompanyAsync(company);
        }

        public Task<Company> GetCompanyByIdAsync(int id)
        {
            return companyDao.GetCompanyByIdAsync(id);
        }
    }
}