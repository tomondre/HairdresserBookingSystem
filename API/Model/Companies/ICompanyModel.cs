using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace API.Model
{
    public interface ICompanyModel
    {
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> GetCompanyByIdAsync(int id);
        Task<IList<Company>> GetAllCompaniesAsync();
        Task<IList<Company>> GetAllPagedCompaniesAsync(int size, int page);
    }
}