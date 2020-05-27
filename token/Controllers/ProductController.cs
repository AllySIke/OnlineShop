using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController: Controller
    {
        private readonly IProductRepository _repo;
        private readonly IWebHostEnvironment _appEnvironment;
        public ProductController(IProductRepository repo, IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
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

        [AllowAnonymous]
        [HttpGet("find/{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            try
            {
                return Ok(await _repo.FindByName(name));
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
        public async Task<IActionResult> Post([FromBody] OnlineShop.DOMAIN.Entities.Product product)//, IFormFile pic)
        
        {
            try
            {
                string path = _appEnvironment.WebRootPath + "\\images\\" + Guid.NewGuid().ToString().Substring(0, 4);// + pic.FileName;
                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await pic.CopyToAsync(fileStream);
                //}
                return Ok(await _repo.Create(product.Name, product.Description, product.Cost, product.CategoryId, path));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "user")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto item)
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

        [Authorize(Roles = "user")]
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

        [AllowAnonymous]
        [HttpGet("findbycat/{category}")]
        public async Task<IActionResult>FindByCategory(Guid category)
        {
            try
            {
                return Ok(await _repo.FindByCategory(category));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
