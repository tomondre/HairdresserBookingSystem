using System;

namespace Shared.Models
{
    public class AppointmentInfo
    {
        public DateTime AvailableTime { get; set; }
        public int MaxProductLength { get; set; }

        public AppointmentInfo()
        {
        }
    }
}