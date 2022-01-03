using System;
using API.Models;

namespace Client.Models
{
    public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Text { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Product Product { get; set; }
    }
}