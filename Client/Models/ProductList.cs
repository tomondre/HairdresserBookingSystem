using System.Collections.Generic;
using API.Models;

namespace Client.Models
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