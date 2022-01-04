using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Persistence;
using Shared.Models;

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

        public Task<IList<Company>> GetAllCompaniesAsync()
        {
            return companyDao.GetAllCompaniesAsync();
        }

        public Task<IList<Company>> GetAllPagedCompaniesAsync(int size, int page)
        {
            return companyDao.GetAllPagedCompaniesAsync(size, page);
        }
    }
}