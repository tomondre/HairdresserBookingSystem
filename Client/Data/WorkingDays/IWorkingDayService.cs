using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IWorkingDayService
    {
        Task<WorkingDayList> GetWorkingDayAsync(int companyId);
    }
}