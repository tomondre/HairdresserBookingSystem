using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IAppointmentService
    {
        Task<WorkingDayList> GetWorkingDayAsync(int companyId);
    }
}