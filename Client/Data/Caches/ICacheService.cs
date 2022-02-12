using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace Client.Data.Users
{
    public interface ICacheService
    {
        Task<User> GetUserAsync();
        Task<Company> GetOpenedCompanyAsync();
        Task SaveUserAsync(User user);
        Task<Company> GetLoggedInUserCompanyAsync();
    }
}