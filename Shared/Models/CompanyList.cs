using System.Collections;
using System.Collections.Generic;

namespace Shared.Models
{
    public class CompanyList
    {
        public IList<Company> Companies { get; set; }

        public CompanyList()
        {
            Companies = new List<Company>();
        }
    }
}