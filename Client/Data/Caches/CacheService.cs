using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace Client.Data.Users
{
    public class CacheService : ICacheService
    {
        public async Task<User> GetCachedUserAsync()
        {
            var user = new User()
            {
                Id = 4,
                Email = "michalko700@gmail.com",
                UserType = "string"
            };

            return user;
        }

        public async Task<Company> GetOpenedCompanyAsync()
        {
            return new Company()
            {
                Id = 3,
                Name = "string"
            };
        }
    }
}