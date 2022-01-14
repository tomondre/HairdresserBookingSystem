using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Persistence.Customers
{
    public class CustomerDao : ICustomerDao
    {
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.Users.FirstOrDefaultAsync(c => c.Email == customer.Email);
            if (firstOrDefaultAsync != null)
            {
                throw new Exception("Customer with the given email already exist!");
            }
            var entityEntry = await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return entityEntry.Entity;

        }
    }
}