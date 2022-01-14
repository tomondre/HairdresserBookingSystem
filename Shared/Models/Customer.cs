namespace Shared.Models
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer Copy()
        {
            return new Customer()
            {
                Id = Id,
                Email = Email,
                Password = Password,
                SecurityType = SecurityType,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}