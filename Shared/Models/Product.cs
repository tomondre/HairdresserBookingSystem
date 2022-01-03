using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        
        [Required, Range(10, 180)]
        public int ProcedureLengthInMinutes { get; set; }
        public int CompanyId { get; set; }
    }
}