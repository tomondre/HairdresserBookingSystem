using System;
using System.Threading.Tasks;
using API.Model;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private ICompanyModel model;
        
        public CompaniesController(ICompanyModel model, IUserModel userModel)
        {
            this.model = model;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompanyAsync([FromBody] Company company)
        {
            try
            {
                var companyAsync = await model.CreateCompanyAsync(company);
                return Ok(companyAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }
        
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Company>> GetCompanyByIdAsync([FromRoute] int id)
        {
            try
            {
                var companyByIdAsync = await model.GetCompanyByIdAsync(id);
                return Ok(companyByIdAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }
    }
}