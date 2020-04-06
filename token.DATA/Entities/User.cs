using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DATA.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string Name { get; set; }
    }
}
