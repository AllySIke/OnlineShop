using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineShop.CORE.Hub;
using OnlineShop.CORE.Hub.Models;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(IHubContext<ChatHub> hubContext)
            {
                _hubContext = hubContext;
            }
        [HttpPost]
        public async Task<ActionResult<bool>> Send([FromBody] Message message)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync("Send", message.Name, message.Text);
                return true;
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}