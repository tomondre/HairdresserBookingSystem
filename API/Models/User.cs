using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }

        public string UserType { get; set; }
    }
}