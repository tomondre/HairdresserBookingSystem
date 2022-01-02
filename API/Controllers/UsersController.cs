using System;
using System.Threading.Tasks;
using API.Model;
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

        [HttpPost]
        public async Task<ActionResult<User>> ValidateUserAsync(User user)
        {
            try
            {
                var validatedUser = model.ValidateUserAsync(user);
                return Ok(validatedUser);
            }
            catch (Exception e)
            {
                return StatusCode(403);
            }
        }
    }
}