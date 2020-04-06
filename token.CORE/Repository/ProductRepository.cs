using Microsoft.EntityFrameworkCore;
using OnlineShop.DOMAIN.Converter;
using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Entities;
using OnlineShop.DOMAIN.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.CORE.EF;

namespace OnlineShop.CORE.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly TContext _context;
        public ProductRepository(TContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> GetAll()
        {
            return await FindCategory(await _context.Products.ToListAsync());
        }
        public async Task<ProductDto> GetById(Guid Id)
        {
            return await FindCategory(await _context.Products.FindAsync(Id));
        }
        public async Task<List<ProductDto>> FindByName(string name)
        {
            var rs = await _context.Products.ToListAsync();
            List<Product> list = new List<Product>();
            foreach (var r in rs)
            {
                if (r.Name.ToLower() == name.ToLower() || r.Name.Split(' ').Count() > 1 && r.Name.ToLower().Split(' ').Contains(name.ToLower()))
                    list.Add(r);
            }
            return await FindCategory(list);
        }

        public async Task<ProductDto> Create(string title, string description, decimal cost, Guid Category, string path)
        {
            var cat = await _context.Categories.FindAsync(Category);
            if (cat == null)
                return null;
            var item = new Product()
            {
                Name = title,
                Description = description,
                Cost = cost,
                CategoryId = cat.Id,
                PicUrl = path
            };
            var result = await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();
            if (result.Entity != null)
                return await FindCategory(item);
            else return null;
        }
        public async Task<bool> Update(ProductDto item)
        {
            _context.Products.Update(ProductConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid Id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (prod == null)
                return false;
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<ProductDto> FindCategory(Product product)
        {
            var cat = await _context.Categories.FindAsync(product.CategoryId);
            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Category = cat.Title,
                Cost = product.Cost,
                PicUrl = product.PicUrl
        };
        }
        public async Task<List<ProductDto>> FindCategory(List<Product> productsDto)
        {
            List<ProductDto> prods = new List<ProductDto>();
            foreach(var prod in productsDto)
            {
                var cat = await FindCategory(prod);
                prods.Add(cat);
            }
            return prods;
        }
        public async Task<List<ProductDto>> FindByCategory(Guid id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
                return null;
            return await FindCategory(await _context.Products.Where(x => x.CategoryId == cat.Id).ToListAsync());
        }
    }
}
