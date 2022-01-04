using System.Security.Cryptography;
using System.Threading.Tasks;
using API.DataAccess;
using Shared.Models;

namespace API.Persistence.Customers
{
    public class CustomerDao : ICustomerDao
    {
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using HairdresserDbContext context = new HairdresserDbContext();
            var entityEntry = await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return entityEntry.Entity;

        }
    }
}