using System;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess;
using Client.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Appointments
{
    public class AppointmentDao : IAppointmentDao
    {
        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            await using HairdresserDbContext context = new HairdresserDbContext();
            var customer = await context.Users.FirstOrDefaultAsync(u => u.Id == appointment.Customer.Id);
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
    }
}