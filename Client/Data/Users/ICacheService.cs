using System.Threading.Tasks;
using API.Models;

namespace Client.Data.Users
{
    public interface ICacheService
    {
        Task<User> GetCachedUserAsync();
    }
}