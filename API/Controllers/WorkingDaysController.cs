﻿using System;
using System.Threading.Tasks;
using API.Model.WorkingDays;
using API.Models;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WorkingDaysController : ControllerBase
    {
        private IWorkingDayModel model;

        public WorkingDaysController(IWorkingDayModel model)
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<WorkingDay>> DeleteWorkingDayAsync([FromRoute] int id)
        {
            try
            {
                var deleteWorkingDayAsync = await model.DeleteWorkingDayAsync(id);
                return Ok(deleteWorkingDayAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }            
        }

        [HttpGet("/companies/{id:int}/WorkingDays")]
        public async Task<ActionResult<WorkingDayList>> GetAllCompanyWorkingDaysAsync([FromRoute] int id)
        {
            try
            {
                WorkingDayList allCompanyWorkingDaysAsync = await model.GetAllCompanyWorkingDaysAsync(id);
                return Ok(allCompanyWorkingDaysAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

        [HttpPatch("{workingDayId:int}")]
        public async Task<ActionResult<WorkingDay>> UpdateWorkingDayAsync([FromBody] WorkingDay workingDay, [FromRoute] int workingDayId)
        {
            try
            {
                var updateWorkingDayAsync = await model.UpdateWorkingDayAsync(workingDayId, workingDay);
                return Ok(updateWorkingDayAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

    }
}