using System;
using System.Threading.Tasks;
using API.Model.WorkingDays;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WorkingDayController : ControllerBase
    {
        private IWorkingDayModel model;

        public WorkingDayController(IWorkingDayModel model)
        {
            this.model = model;
        }

        [HttpPost]
        public async Task<ActionResult<WorkingDay>> CreateWorkingDayAsync([FromBody] WorkingDay workingDay)
        {
            try
            {
                WorkingDay workingDayAsync = await model.CreateWorkingDayAsync(workingDay);
                return Ok(workingDayAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

    }
}