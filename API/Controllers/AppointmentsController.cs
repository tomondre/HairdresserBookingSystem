using System;
using System.Threading.Tasks;
using API.Model.Appointments;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private IAppointmentModel model;

        public AppointmentsController(IAppointmentModel model)
        {
            this.model = model;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointmentAsync([FromBody] Appointment appointment)
        {
            try
            {
                Appointment create = await model.CreateAppointmentAsync(appointment);
                return Ok(create);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);

            }
        }

        [HttpGet("/companies/{id:int}/appointments")]
        public async Task<ActionResult<AppointmentList>> GetAllCompanyAppointmentsAsync([FromRoute] int id)
        {
            try
            {
                AppointmentList result = await model.GetAllCompanyAppointmentsAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Appointment>> DeleteAppointmentAsync([FromRoute] int id)
        {
            try
            {
                var deleteAppointmentAsync = await model.DeleteAppointmentAsync(id);
                return Ok(deleteAppointmentAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

    }
}