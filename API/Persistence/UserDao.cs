using System;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class UserDao : IUserDao
    {
        public async Task<User> ValidateUserAsync(User user)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var first = await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (first == null)
            {
                throw new Exception("User doesnt exist");
            }

            if (!(first.Password == user.Password))
            {
                throw new Exception("Incorrect Password");
            }

            return first;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            using HairdresserDbContext context = new HairdresserDbContext();
            var entityEntry = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}