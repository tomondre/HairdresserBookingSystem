using System;
using System.Threading.Tasks;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Persistence.CompanyOwners
{
    public class CompanyOwnerDao : PaginationHelper, ICompanyOwnerDao
    {
        public async Task<CompanyOwner> CreateCompanyOwnerAsync(CompanyOwner companyOwner)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            
            var orDefaultAsync = await context.Users.FirstOrDefaultAsync(u => u.Email == companyOwner.Email);
            if (orDefaultAsync != null)
            {
                throw new Exception("User with the same email already exist!");
            }
            
            var firstOrDefaultAsync = await context.Companies.FirstOrDefaultAsync(c => c.Name == companyOwner.Company.Name);
            if (firstOrDefaultAsync != null)
            {
                throw new Exception("Company with the same name already exist!");
            }

            var entityEntry = await context.CompanyOwners.AddAsync(companyOwner);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Company> GetCompanyByCompanyOwnerIdAsync(int id)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.CompanyOwners.Include(c => c.Company).FirstOrDefaultAsync();

            if (firstOrDefaultAsync == null)
            {
                throw new Exception("Company Owner With the given id doesnt exist!");
            }

            return firstOrDefaultAsync.Company;
        }
    }
}