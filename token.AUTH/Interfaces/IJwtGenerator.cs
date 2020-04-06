using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DATA.Entities;
using refresh.CORE.Models;

namespace OnlineShop.AUTH.Interfaces
{
    public interface IJwtGenerator
    {
        Task<Response<Token>> GenerateJwt(User user);
    }
}
