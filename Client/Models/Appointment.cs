using System;
using API.Models;
using Shared.Models;

namespace Client.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }

        public virtual DateTime End
        {
            get { return Start.AddMinutes(Product.ProcedureLengthInMinutes); }
            set { }
        }

        public virtual string Text
        {
            get { return Product.Name; }
            set { }
        }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        
        public Appointment()
        {
            Customer = new Customer();
            Start = new DateTime();
            Product = new Product();
        }
    }
}