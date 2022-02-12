using System.Collections.Generic;
using Client.Models;

namespace API.Models
{
    public class WorkingDayList
    {
        public IList<WorkingDay> Days { get; set; }
        public WorkingDayList()
        {
            Days = new List<WorkingDay>();
        }
    }
}