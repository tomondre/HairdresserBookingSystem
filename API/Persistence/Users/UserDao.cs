using System;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

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

            if (first.Password != user.Password)
            {
                throw new Exception("Incorrect Password");
            }

            //Want to fetch company if logged in user is CompanyOwner
            //This is very stupid solution
            if (first is CompanyOwner)
            {
                first = await context.CompanyOwners.Include(co => co.Company).FirstOrDefaultAsync(u => u.Email == user.Email);
            }

            first.UserType = first.GetType().Name;
            return first;
        }
    }
}