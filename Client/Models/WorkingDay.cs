using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using API.Models;
using Shared.Models;

namespace Client.Models
{
    public class WorkingDay
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime StartBreak { get; set; }
        public Company Company { get; set; }
        public int BreakLengthInMinutes { get; set; }

        private IList<Appointment> Appointments { get; set; }

        public IList<Appointment> AppointmentsIncludingWorkingDay
        {
            get
            {
                var result = new List<Appointment>(Appointments);
                result.Add(new WorkSchedule()
                {
                    Start = Start,
                    End = End,
                    Text = "Otváracie hodiny"
                });
                return result;
            }
        }

        public DateTime EndBreak => StartBreak.AddMinutes(BreakLengthInMinutes);

        public WorkingDay()
        {
            Appointments = new List<Appointment>();
            Start = new DateTime();
            End = new DateTime();
            Company = new Company();
        }

        public void AddAppointment(Appointment appointment)
        {
            //Check for appointments if are not one on another
        }
    }
}