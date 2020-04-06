using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.DOMAIN.Converter
{
    public class CategoryConverter
    {
        public static Category Convert(CategoryDto item) =>
            new Category
            {
                Id = item.Id,
                Title = item.Title
            };

        public static CategoryDto Convert(Category item) =>
            new CategoryDto
            {
                Id = item.Id,
                Title = item.Title
            };

        public static List<Category> Convert(List<CategoryDto> items) =>
            items.Select(u => Convert(u)).ToList();

        public static List<CategoryDto> Convert(List<Category> items) =>
            items.Select(u => Convert(u)).ToList();
    }
}
