using System.Threading.Tasks;
using Shared.Models;

namespace Client.Data.Customers
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}