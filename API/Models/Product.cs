using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public int ProcedureLengthInMinutes { get; set; }
        public int CompanyId { get; set; }
    }
}