using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.DOMAIN.Converter
{
    public class ProductConverter
    {
        public static Product Convert(ProductDto item) =>
            new Product
            {
                Id = item.Id,
                Description = item.Description,
                Name = item.Name,
                Cost = item.Cost,
                PicUrl = item.PicUrl
            };

        public static ProductDto Convert(Product item) =>
            new ProductDto
            {
                Id = item.Id,
                Description = item.Description,
                Name = item.Name,
                Cost = item.Cost,
                PicUrl = item.PicUrl
            };

        public static List<Product> Convert(List<ProductDto> items) =>
            items.Select(u => Convert(u)).ToList();

        public static List<ProductDto> Convert(List<Product> items) =>
            items.Select(u => Convert(u)).ToList();
    }
}
