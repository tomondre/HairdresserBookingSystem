using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using API.Persistence.Customers;
using Shared.Models;

namespace API.Model.Customers
{
    public class CustomerModel : ICustomerModel
    {
        private ICustomerDao dao;

        public CustomerModel(ICustomerDao dao)
        {
            this.dao = dao;
        }

        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            return dao.CreateCustomerAsync(customer);
        }
    }
}