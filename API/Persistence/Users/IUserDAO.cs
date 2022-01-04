using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace API.Persistence
{
    public interface IUserDao
    {
        Task<User> ValidateUserAsync(User user);
    }
}