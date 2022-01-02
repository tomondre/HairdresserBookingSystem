using API.Persistence;
using Shared.Models;

namespace API.Model
{
    public interface IUserModel
    {
        User ValidateUserAsync(User user);
    }
}