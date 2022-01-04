using System;
using System.ComponentModel.DataAnnotations;
using API.Models;
using Shared.Models;

namespace Client.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int WorkingDayId { get; set; }

        public Appointment()
        {
            Customer = new Customer();
            Start = new DateTime();
            Product = new Product();
        }
    }
}