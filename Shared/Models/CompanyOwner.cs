namespace Shared.Models
{
    public class CompanyOwner : User
    {
        public Company Company { get; set; }

        public CompanyOwner()
        {
            Company = new Company();
        }

        public CompanyOwner Copy()
        {
            return new CompanyOwner
            {
                Id = Id,
                Email = Email,
                Password = Password,
                Company = Company,
                SecurityType = SecurityType
            };
        }
    }
}