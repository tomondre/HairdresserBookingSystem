using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        
        [Required, RegularExpression(@"\b[A-Fa-f0-9]{64}\b",ErrorMessage =
             "Password needs to be a hash key!")]
        public string Password { get; set; }

        public string UserType { get; set; }
    }
}