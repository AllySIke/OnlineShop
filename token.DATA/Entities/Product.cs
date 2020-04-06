using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DOMAIN.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Cost { get; set; }
        public string PicUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
