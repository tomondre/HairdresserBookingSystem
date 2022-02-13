using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.Model.WorkingDays;
using API.Persistence.Appointments;
using Client.Models;
using Shared.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Model.Appointments
{
    public class AppointmentModel : IAppointmentModel
    {
        private IAppointmentDao dao;
        private IWorkingDayModel workingDayModel;

        public AppointmentModel(IAppointmentDao dao, IWorkingDayModel workingDayModel)
        {
            this.dao = dao;
            this.workingDayModel = workingDayModel;
        }

        public Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            return dao.CreateAppointmentAsync(appointment);
        }

        public Task<AppointmentList> GetAllCompanyAppointmentsAsync(int id)
        {
            return dao.GetAllCompanyAppointmentsAsync(id);
        }

        public Task<Appointment> DeleteAppointmentAsync(int id)
        {
            return dao.DeleteAppointmentAsync(id);
        }

        public async Task<AppointmentInfoList> GetCompanyAppointmentInfosAsync(int id)
        {
            var allCompanyWorkingDaysAsync = await workingDayModel.GetAllCompanyWorkingDaysAsync(id);

            var appointmentInfoList = new AppointmentInfoList();
            foreach (var day in allCompanyWorkingDaysAsync.Days)
            {
                var appointment = day.Appointments.Last();
                var lastTime = appointment.Start.AddMinutes(appointment.Product.ProcedureLengthInMinutes);
                
                // Do not forget about the case when break occur
                
                // We need to create some kind of offset because the breaks wont be perfectly times - each product has different length in minutes
                
                // Calculate difference between lastTime and working day end time

                // Check if the result is smaller than zero, if so do not create appointment info
                
            }

            throw new System.NotImplementedException();
        }
    }
}