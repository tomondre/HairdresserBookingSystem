using System.Threading.Tasks;
using Client.Models;

namespace API.Persistence.Appointments
{
    public interface IAppointmentDao
    {
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
    }
}