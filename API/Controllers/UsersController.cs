using System;
using System.Threading.Tasks;
using API.Model;
using API.Models;
using Microsoft.AspNetCore.Mvc;

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
                return StatusCode(401, e.Message);
            }
        }

        [HttpPost("signup")]
        public async Task<ActionResult<User>> CreateUserAsync([FromBody] User user)
        {
            try
            {
                var userAsync = await model.CreateUserAsync(user);
                return Ok(userAsync);
            }
            catch (Exception e)
            {
                return StatusCode(401, e.Message);
            }
        }
    }
}