using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.DATA.Dto;
using OnlineShop.DATA.Entities;

namespace OnlineShop.DATA.Converter
{
    public static class UserConverter
    {
        public static User Convert(UserDto item) =>
            new User
            {
                Email = item.Email,
                UserName = item.Email,
                Id = item.Id,
                Name = item.Name
            };

        public static UserDto Convert(User item) =>
            new UserDto
            {
                Email = item.Email,
                Id = item.Id,
                Name = item.Name
            };

        public static List<User> Convert(List<UserDto> items) =>
            items.Select(u => Convert(u)).ToList();

        public static List<UserDto> Convert(List<User> items) =>
            items.Select(u => Convert(u)).ToList();
    }
}
