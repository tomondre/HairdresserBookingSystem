using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API.DataAccess;
using API.Models;
using Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shared.Models;

namespace API.Persistence.Appointments
{
    public class AppointmentDao : IAppointmentDao
    {
        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var customer = await context.Users.OfType<Customer>()
                .FirstOrDefaultAsync(u => u.Id == appointment.Customer.Id);
            if (customer == null)
            {
                throw new Exception("Assigned user doesn't exist");
            }

            appointment.Customer = customer;

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == appointment.Product.Id);
            if (product == null)
            {
                throw new Exception("Assigned product doesnt exist");
            }

            appointment.Product = product;

            var workingDay = await context.WorkingDays.FirstOrDefaultAsync(w => w.Id == appointment.WorkingDayId);
            if (workingDay == null)
            {
                throw new Exception("Assigned working day doesn't exist");
            }

            var entityEntry = await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<AppointmentList> GetAllCompanyAppointmentsAsync(int id)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();

            var appointments =
                from a in context.Appointments
                where a.Product.CompanyId == id
                select new Appointment()
                {
                    Id = a.Id,
                    Start = a.Start,
                    WorkingDayId = a.WorkingDayId,
                    Customer = (from c in context.Customers where c.Id == a.Customer.Id select c).FirstOrDefault(),
                    Product = (from p in context.Products where a.Product.Id == p.Id select p).FirstOrDefault()
                };

            if (!appointments.Any())
            {
                throw new Exception("Company doesn't contain any appointments or company doesn't exist");
            }

            return new AppointmentList
            {
                Appointments = await appointments.OrderByDescending(a => a.Start).ToListAsync()
            };
        }
    }
}