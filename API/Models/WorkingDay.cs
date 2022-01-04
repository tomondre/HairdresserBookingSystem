using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Models;
using Shared.Models;

namespace Client.Models
{
    public class WorkingDay
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public DateTime StartBreak { get; set; }
        [Required]
        public Company Company { get; set; }
        public int BreakLengthInMinutes { get; set; }
        public IList<Appointment> Appointments { get; set; }
        
        public WorkingDay()
        {
            Company = new Company();
            Appointments = new List<Appointment>();
            Start = new DateTime();
            End = new DateTime();
        }
    }
}