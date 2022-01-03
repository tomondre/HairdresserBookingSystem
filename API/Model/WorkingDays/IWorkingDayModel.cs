using System.Threading.Tasks;
using Client.Models;

namespace API.Model.WorkingDays
{
    public interface IWorkingDayModel
    {
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay workingDay);
    }
}