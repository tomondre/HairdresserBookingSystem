using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Persistence
{
    public class CompanyDao : PaginationHelper, ICompanyDao
    {
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