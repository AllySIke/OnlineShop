using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.API.ViewModels;
using OnlineShop.AUTH.Interfaces;
using OnlineShop.DATA.Dto;
using token.AUTH.Interfaces;
using refresh.CORE.Models;
using refresh.API.Models;
using refresh.API.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop.API.Controllers
{
    [Route("api/auth/[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _auth;


        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> Login([FromBody] LoginViewModel form)
        {
            try
            {
                var result = await _auth.Login(form.Email, form.Password);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> Register([FromBody] UserDto item)
        
        {
            try
            {
                var result = await _auth.Register(item);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> RefreshToken([FromBody] RefreshViewModel item)
        {
            try
            {
                var result = await _auth.RefreshToken(item.AccessToken, item.RefreshToken);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpGet]
        [Authorize]
        [Produces(typeof(bool))]
        public ActionResult<bool> Test()
        {
            return true;
        }
    }
}
