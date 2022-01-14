using System.Threading.Tasks;
using Shared.Models;

namespace Client.Data.Companies
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByIdAsync(int id);
    }
}