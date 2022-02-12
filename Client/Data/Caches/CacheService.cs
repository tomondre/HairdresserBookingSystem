using System.Threading.Tasks;
using Client.Data.Companies;
using Client.Data.CompanyOwners;
using Client.Data.Users;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Shared.Models;

namespace Client.Data.Caches
{
    public class CacheService : ICacheService
    {
        private ProtectedSessionStorage sessionStorage;
        private ICompanyOwnerService companyOwnerService;

        public CacheService(ProtectedSessionStorage sessionStorage, ICompanyOwnerService companyOwnerService)
        {
            this.sessionStorage = sessionStorage;
            this.companyOwnerService = companyOwnerService;
        }
        
        public async Task<User> GetUserAsync()
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<User>("currentUser");
            return protectedBrowserStorageResult.Value;
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

        public async Task<Company> GetLoggedInCompanyUserCompanyAsync()
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<Company>("loggedInCompany");
            if (!protectedBrowserStorageResult.Success)
            {
                var userAsync = await GetUserAsync();
                var company = await companyOwnerService.GetCompanyByCompanyOwnerIdAsync(userAsync.Id);
                await sessionStorage.SetAsync("loggedInCompany", company);
                return company;
            }

            return protectedBrowserStorageResult.Value;
        }
    }
}