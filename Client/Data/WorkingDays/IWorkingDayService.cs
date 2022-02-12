using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IWorkingDayService
    {
        Task<WorkingDayList> GetWorkingDayListAsync(int companyId);
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay model);
        Task<WorkingDay> DeleteWorkingDayAsync(int workingDayId);
        Task<WorkingDay> UpdateWorkingDayAsync(WorkingDay workingDay);
    }
}