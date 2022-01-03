using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required, Range(10, 180)]
        public int ProcedureLengthInMinutes { get; set; }
        public int CompanyId { get; set; }
    }
}