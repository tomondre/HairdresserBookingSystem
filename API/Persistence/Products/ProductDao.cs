using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Shared.Models;

namespace API.Persistence
{
    public class ProductDao : PaginationHelper, IProductDao
    {
        public async Task<Product> CreateProductAsync(Product product)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.Companies.FirstOrDefaultAsync(company => company.Id == product.CompanyId);
            if (firstOrDefaultAsync == null)
            {
                throw new Exception("Company Not Found");
            }

            var entityEntry = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.Products.FirstOrDefaultAsync((product) => product.Id == id);
            if (firstOrDefaultAsync == null)
            {
                throw new Exception("Product doesnt exist");
            }

            return firstOrDefaultAsync;
        }

        public async Task<IList<Product>> GetCompanyProductsAsync(int id)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.Companies.Include(c => c.Products).FirstOrDefaultAsync(company => company.Id == id);
            if (firstOrDefaultAsync == null)
            {
                throw new Exception("Company doesnt exist");
            }

            return firstOrDefaultAsync.Products;
        }

        public async Task<IList<Product>> GetPagedCompanyProductsAsync(int id, int size, int page)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            Company firstOrDefaultAsync = await context.Companies.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            var products = Page(firstOrDefaultAsync.Products, page, size);
            return products;
        }
    }
}