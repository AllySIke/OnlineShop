﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DATA.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
}
