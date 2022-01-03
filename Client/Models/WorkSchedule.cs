using System;

namespace Client.Models
{
    public class WorkSchedule : Appointment
    {
        public override DateTime End { get; set; }
        public override string Text { get; set; }

    }
}