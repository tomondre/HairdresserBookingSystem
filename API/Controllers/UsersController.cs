using System;
using System.Threading.Tasks;
using API.Model;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserModel model;
        
        public UsersController(IUserModel userModel)
        {
            model = userModel;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> ValidateUserAsync([FromBody] User user)
        {
            try
            {
                var validatedUser = await model.ValidateUserAsync(user);
                return Ok(validatedUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(401, e.Message);
            }
        }
    }
}