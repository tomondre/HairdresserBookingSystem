using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private ICompanyModel model;
        
        public CompaniesController(ICompanyModel model)
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

        [HttpGet]
        public async Task<ActionResult<IList<Company>>> GetAllCompanies([FromQuery] int? size, [FromQuery] int? page)
        {
            try
            {
                IList<Company> allCompaniesAsync;
                if (size.HasValue && page.HasValue)
                {
                    allCompaniesAsync = await model.GetAllPagedCompaniesAsync(size.Value, page.Value);
                }
                else
                {
                    allCompaniesAsync = await model.GetAllCompaniesAsync();
                }
                
                return Ok(allCompaniesAsync);
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