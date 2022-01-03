﻿using System;
using System.Collections.Generic;
using API.Models;

namespace Client.Models
{
    public class WorkingDay
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime StartBreak { get; set; }
        public int BreakLengthInMinutes { get; set; }

        private IList<Appointment> _appointments;

        public IList<Appointment> Appointments
        {
            get
            {
                var result = new List<Appointment>(_appointments);
                result.Add(new WorkSchedule()
                {
                    Start = Start,
                    End = End,
                    Text = "Otváracie hodiny"
                });
                return result;
            }
            set
            {
                _appointments = value;
            }
        }

        public DateTime EndBreak => StartBreak.AddMinutes(BreakLengthInMinutes);

        public WorkingDay()
        {
            _appointments = new List<Appointment>();
            Start = new DateTime();
            End = new DateTime();
        }

        public void AddAppointment(Appointment appointment)
        {
            //Check for appointments if are not one on another
        }
    }
}