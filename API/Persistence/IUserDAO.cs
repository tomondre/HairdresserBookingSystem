using Shared.Models;

namespace API.Persistence
{
    public interface IUserDao
    {
        User ValidateUserAsync(User user);
    }
}