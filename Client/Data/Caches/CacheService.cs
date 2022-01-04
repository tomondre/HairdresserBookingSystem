using System.Threading.Tasks;
using Client.Data.Users;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Shared.Models;

namespace Client.Data.Caches
{
    public class CacheService : ICacheService
    {
        private ProtectedSessionStorage sessionStorage;

        public CacheService(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }
        
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

        public async Task SaveUserAsync(User user)
        {
            await sessionStorage.SetAsync("currentUser", user);
        }
        
        public async Task<User> GetUserAsync(User user)
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<User>("currentUser");
            return protectedBrowserStorageResult.Value;
        }
    }
}