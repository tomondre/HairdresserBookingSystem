using System;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class CompanyDao : ICompanyDao
    {
        public async Task<Company> CreateCompanyAsync(Company company)
        {
            try
            {
                await using HairdresserDbContext context = new HairdresserDbContext();
                var firstOrDefaultAsync = await context.Users.FirstOrDefaultAsync((user) => user.Id == company.User.Id);
                if (firstOrDefaultAsync == null)
                {
                    throw new Exception("User doesnt exist");
                }

                company.User = firstOrDefaultAsync;
                var entityEntry = context.Companies.Add(company);
                await context.SaveChangesAsync();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            try
            {
                await using HairdresserDbContext context = new HairdresserDbContext();
                var firstOrDefaultAsync = await context.Companies.FirstOrDefaultAsync(c => c.Id == id);
                if (firstOrDefaultAsync == null)
                {
                    throw new Exception("Company not found");
                }

                return firstOrDefaultAsync;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}