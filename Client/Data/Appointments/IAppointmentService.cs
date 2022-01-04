using System.Threading.Tasks;
using Client.Models;

namespace Client.Data.Appointments
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
    }
}