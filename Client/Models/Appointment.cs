using System;
using API.Models;

namespace Client.Models
{
    public class Appointment
    {
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

        public WorkingDay WorkingDay { get; set; }
        public Product Product { get; set; }

        public Appointment()
        {
            Start = new DateTime();
            WorkingDay = new WorkingDay();
            Product = new Product();
        }
    }
}