using System;
using System.Linq;
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

            workingDay.Company = firstOrDefaultAsync;
            var entityEntry = context.WorkingDays.Add(workingDay);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<WorkingDayList> GetAllCompanyWorkingDaysAsync(int id)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            IQueryable<WorkingDay> days;
            days = context.WorkingDays.Include(d => d.Appointments).ThenInclude(a => a.Product).Where(d => d.Company.Id == id);
            if (!days.Any())
            {
                throw new Exception("Company hasn't created working days or company doesn't exist");
            }

            return new WorkingDayList()
            {
                Days = await days.ToListAsync()
            };
        }
    }
}