using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public User User { get; set; }

        public IList<Product> Products { get; set; }
    }
}