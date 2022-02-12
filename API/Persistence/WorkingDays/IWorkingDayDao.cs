using System.Threading.Tasks;
using API.Models;
using Client.Models;

namespace API.Persistence.WorkingDays
{
    public interface IWorkingDayDao
    {
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay workingDay);
        Task<WorkingDayList> GetAllCompanyWorkingDaysAsync(int id);
        Task<WorkingDay> DeleteWorkingDayAsync(int id);
    }
}