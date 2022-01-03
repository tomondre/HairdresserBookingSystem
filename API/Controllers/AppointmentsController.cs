﻿using System;
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

    }
}