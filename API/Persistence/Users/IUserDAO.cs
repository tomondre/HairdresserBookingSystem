using System.Threading.Tasks;
using API.Models;

namespace API.Persistence
{
    public interface IUserDao
    {
        Task<User> ValidateUserAsync(User user);
        Task<User> CreateUserAsync(User user);
    }
}