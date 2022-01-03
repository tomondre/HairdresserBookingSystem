using System;
using System.Threading.Tasks;
using API.DataAccess;
using Client.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.WorkingDays
{
    public class WorkingDayDao : IWorkingDayDao
    {
        public async Task<WorkingDay> CreateWorkingDayAsync(WorkingDay workingDay)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var firstOrDefaultAsync = await context.Companies.FirstOrDefaultAsync(c => c.Id == workingDay.Company.Id);
            if (firstOrDefaultAsync == null)
            {
                throw new Exception("Assigned company doesnt exist");
            }

            var entityEntry = context.WorkingDays.Add(workingDay);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}