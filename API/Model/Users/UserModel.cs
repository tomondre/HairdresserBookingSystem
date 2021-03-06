using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using API.Models;
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
        
        public async Task<User> ValidateUserAsync(User user)
        {
            return await userDao.ValidateUserAsync(user);
        }

    }
}