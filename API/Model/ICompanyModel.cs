using System.Threading.Tasks;
using API.Models;

namespace API.Model
{
    public interface ICompanyModel
    {
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> GetCompanyByIdAsync(int id);
    }
}