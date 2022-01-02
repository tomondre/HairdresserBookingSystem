using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class CompanyDao : PaginationHelper, ICompanyDao
    {
        public async Task<Company> CreateCompanyAsync(Company company)
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

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (firstOrDefaultAsync == null)
            {
                throw new Exception("Company not found");
            }

            return firstOrDefaultAsync;
        }

        public async Task<IList<Company>> GetAllCompaniesAsync()
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var contextCompanies = await context.Companies.ToListAsync();
            return contextCompanies;
        }

        public async Task<IList<Company>> GetAllPagedCompaniesAsync(int size, int page)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var contextCompanies = await context.Companies.ToListAsync();
            var list = Page(contextCompanies, page, size);
            return list;
        }
    }
}