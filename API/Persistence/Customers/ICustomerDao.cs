using System.Threading.Tasks;
using Shared.Models;

namespace API.Persistence.Customers
{
    public interface ICustomerDao
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}