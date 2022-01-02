using System.Runtime.InteropServices.ComTypes;
using API.Persistence;
using Shared.Models;

namespace API.Model
{
    public class UserModel : IUserModel
    {
        private IUserDao userDao;
        
        public UserModel(IUserDao userDao)
        {
            this.userDao = userDao;
        }
        
        public User ValidateUserAsync(User user)
        {
            return userDao.ValidateUserAsync(user);
        }
    }
}