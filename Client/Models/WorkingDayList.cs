using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace Client.Models
{
    public class WorkingDayList
    {
        public IList<WorkingDay> Days { get; set; }

        public WorkingDayList()
        {
            Days = new List<WorkingDay>();
        }

        public IList<Appointment> Appointments
        {
            get
            {
                List<Appointment> appointments = new List<Appointment>();
                foreach (var day in Days)
                {
                    appointments.AddRange(day.Appointments);
                }

                return appointments;
            }
        }
    }
}