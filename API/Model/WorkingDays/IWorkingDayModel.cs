using System.Threading.Tasks;
using API.Models;
using Client.Models;

namespace API.Model.WorkingDays
{
    public interface IWorkingDayModel
    {
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay workingDay);
        Task<WorkingDayList> GetAllCompanyWorkingDaysAsync(int id);
        Task<WorkingDay> DeleteWorkingDayAsync(int id);
    }
}