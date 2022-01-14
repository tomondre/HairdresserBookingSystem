using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;

namespace Shared.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string UserType { get; set; }

        public User Copy()
        {
            return new User()
            {
                Id = Id,
                Email = Email,
                Password = Password,
                UserType = UserType
            };
        }
    }
}