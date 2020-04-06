using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DOMAIN.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
