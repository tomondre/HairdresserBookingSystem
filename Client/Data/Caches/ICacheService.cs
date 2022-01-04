﻿using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace Client.Data.Users
{
    public interface ICacheService
    {
        Task<User> GetCachedUserAsync();
        Task<Company> GetOpenedCompanyAsync();
        Task SaveUserAsync(User user);
        Task<User> GetUserAsync(User user);
    }
}