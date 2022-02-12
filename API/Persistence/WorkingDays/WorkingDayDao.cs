using System;
using System.Collections.Generic;
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

            var days =
                from w in context.WorkingDays
                where w.Company.Id == id
                select new WorkingDay()
                {
                    Id = w.Id,
                    Company = w.Company,
                    Appointments = (from a in context.Appointments
                        where a.WorkingDayId == w.Id
                        select new Appointment()
                        {
                            Id = a.Id,
                            Product = (from p in context.Products where a.Product.Id == p.Id select p).FirstOrDefault(),
                            Customer =
                                (from c in context.Customers where a.Customer.Id == c.Id select c).FirstOrDefault()
                        }).ToList()
                };

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