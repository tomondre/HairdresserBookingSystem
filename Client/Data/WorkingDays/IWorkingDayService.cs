using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IWorkingDayService
    {
        Task<WorkingDayList> GetWorkingDayListAsync(int companyId);
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay model);
        Task<WorkingDay> DeleteWorkingDay(int workingDayId);
    }
}