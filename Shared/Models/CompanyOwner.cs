namespace Shared.Models
{
    public class CompanyOwner : User
    {
        public string EmployeeType { get; set; }
        public Company Company { get; set; }
    }
}