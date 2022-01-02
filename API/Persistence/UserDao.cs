using Shared.Models;

namespace API.Persistence
{
    public class UserDao : IUserDao
    {
        public User ValidateUserAsync(User user)
        {
            //TODO database check, if not valid, throw exception
            return user;
        }
    }
}