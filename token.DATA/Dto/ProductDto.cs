using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DOMAIN.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string PicUrl { get; set; }
        public string Category { get; set; }
    }
}
