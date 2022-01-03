using System.Collections.Generic;

namespace Client.Models
{
    public class WorkingDayList
    {
        public IList<WorkingDay> Days { get; set; }

        public IList<Appointment> Appointments
        {
            get
            {
                var result = new List<Appointment>();
                foreach (var day in Days)
                {
                    result.AddRange(day.Appointments);
                }

                return result;
            }
        }

        public WorkingDayList()
        {
            Days = new List<WorkingDay>();
        }
    }
}