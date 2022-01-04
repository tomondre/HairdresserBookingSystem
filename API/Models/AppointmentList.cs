using System.Collections.Generic;

namespace Client.Models
{
    public class AppointmentList
    {
        public IList<Appointment> Appointments { get; set; }

        public AppointmentList()
        {
            Appointments = new List<Appointment>();
        }

    }
}