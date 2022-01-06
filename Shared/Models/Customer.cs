namespace Shared.Models
{
    public class Customer : User
    {
        public override string UserType { get; set; } = "Customer";
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer Copy()
        {
            return new Customer()
            {
                Id = Id,
                Email = Email,
                Password = Password,
                UserType = UserType,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}