using System.Threading.Tasks;
using API.Models;

namespace API.Persistence
{
    public interface ICompanyDao
    {
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> GetCompanyByIdAsync(int id);
    }
}