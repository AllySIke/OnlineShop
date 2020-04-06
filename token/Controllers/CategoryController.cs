using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet("find/{title}")]
        public async Task<IActionResult> FindByName(string title)
        {
            try
            {
                return Ok(await _repo.FindByTitle(title));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _repo.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto title)
        {
            try
            {
                return Ok(await _repo.Create(title));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDto item)
        {
            try
            {
                return Ok(await _repo.Update(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _repo.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "user")]
        [HttpDelete("title/{title}")]
        public async Task<IActionResult> DeleteByTitle(string title)
        {
            try
            {
                return Ok(await _repo.DeleteByTitle(title));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
