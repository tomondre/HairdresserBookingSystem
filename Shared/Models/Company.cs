using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace Shared.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public CompanyOwner User { get; set; }

        public IList<Product> Products { get; set; }
        
        public Company()
        {
            User = new CompanyOwner();
        }
    }
}