using System;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace Client.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public User Customer { get; set; }
        [Required]
        public Product Product { get; set; }

        public Appointment()
        {
            Customer = new User();
            Start = new DateTime();
            Product = new Product();
        }
    }
}