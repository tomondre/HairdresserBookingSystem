using System.Threading.Tasks;
using Shared.Models;

namespace API.Model.Customers
{
    public interface ICustomerModel
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}