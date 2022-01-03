using System.Threading.Tasks;
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
    }
}