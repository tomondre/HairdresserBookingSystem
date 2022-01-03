using System.Threading.Tasks;
using Client.Models;

namespace API.Persistence.WorkingDays
{
    public interface IWorkingDayDao
    {
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay workingDay);
        Task<WorkingDayList> GetAllCompanyWorkingDaysAsync(int id);
    }
}