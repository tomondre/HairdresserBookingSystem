using System;
using System.Threading.Tasks;
using API.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private ICustomerModel model;
        
        public CustomersController(ICustomerModel model)
        {
            this.model = model;
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                var userAsync = await model.CreateCustomerAsync(customer);
                return Ok(userAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(401, e.Message);
            }
        }
    }
}