using System.Threading.Tasks;
using API.Models;
using API.Persistence;

namespace API.Model
{
    public interface IUserModel
    {
        Task<User> ValidateUserAsync(User user);
        Task<User> CreateUserAsync(User user);
    }
}