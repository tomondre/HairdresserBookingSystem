using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace Client.Data.Users
{
    public interface IUserService
    {
        Task<User> TryLoginUserAsync(User user);
    }
}