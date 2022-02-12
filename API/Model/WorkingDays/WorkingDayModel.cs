using System.Threading.Tasks;
using API.Models;
using API.Persistence.WorkingDays;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Model.WorkingDays
{
    public class WorkingDayModel : IWorkingDayModel
    {
        private IWorkingDayDao dao;

        public WorkingDayModel(IWorkingDayDao dao)
        {
            this.dao = dao;
        }
        
        public Task<WorkingDay> CreateWorkingDayAsync(WorkingDay workingDay)
        { 
            return dao.CreateWorkingDayAsync(workingDay);
        }

        public Task<WorkingDayList> GetAllCompanyWorkingDaysAsync(int id)
        {
            return dao.GetAllCompanyWorkingDaysAsync(id);
        }

        public Task<WorkingDay> DeleteWorkingDayAsync(int id)
        {
            return dao.DeleteWorkingDayAsync(id);
        }

        public Task<WorkingDay> UpdateWorkingDayAsync(int workingDayId, WorkingDay workingDay)
        {
            return dao.UpdateWorkingDayAsync(workingDayId, workingDay);
        }
    }
}