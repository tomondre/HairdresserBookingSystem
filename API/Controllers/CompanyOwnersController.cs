using System;
using System.Threading.Tasks;
using API.Model.CompanyOwners;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyOwnersController : ControllerBase
    {
        private ICompanyOwnerModel model;

        public CompanyOwnersController(ICompanyOwnerModel model)
        {
            this.model = model;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyOwner>> CreateCompanyOwnerAsync([FromBody] CompanyOwner companyOwner)
        {
            try
            {
                var companyOwnerAsync = await model.CreateCompanyOwnerAsync(companyOwner);
                return Ok(companyOwnerAsync);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }
    }
}