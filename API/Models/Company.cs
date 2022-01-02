using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        public User User { get; set; }

        public IList<Product> Products { get; set; }
    }
}