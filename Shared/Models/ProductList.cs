using System.Collections.Generic;
using API.Models;

namespace Shared.Models
{
    public class ProductList
    {
        public IList<Product> Products { get; set; }

        public ProductList()
        {
            Products = new List<Product>();
        }
    }
}