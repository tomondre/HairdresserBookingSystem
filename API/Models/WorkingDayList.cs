using System.Collections.Generic;

namespace Client.Models
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