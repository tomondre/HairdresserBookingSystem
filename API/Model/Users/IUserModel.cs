using System.Threading.Tasks;
using API.Models;
using API.Persistence;
using Shared.Models;

namespace API.Model
{
    public interface IUserModel
    {
        Task<User> ValidateUserAsync(User user);
    }
}