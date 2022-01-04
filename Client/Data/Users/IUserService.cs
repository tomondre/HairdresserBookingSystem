using System.Threading.Tasks;
using API.Models;

namespace Client.Data.Users
{
    public interface IUserService
    {
        Task<User> TryLoginUserAsync(User user);
    }
}