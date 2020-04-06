using Microsoft.EntityFrameworkCore;
using OnlineShop.DOMAIN.Converter;
using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Entities;
using OnlineShop.DOMAIN.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.CORE.EF;

namespace OnlineShop.CORE.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly TContext _context;
        public CategoryRepository(TContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            return CategoryConverter.Convert(await _context.Categories.ToListAsync());
        }
        public async Task<CategoryDto> GetById(Guid Id)
        {
            return CategoryConverter.Convert(await _context.Categories.FindAsync(Id));
        }
        public async Task<CategoryDto> FindByTitle(string title)
        {
            try
            {
                return CategoryConverter.Convert(await _context.Categories.FirstOrDefaultAsync(a => a.Title.ToLower() == title.ToLower()));
            }
            catch
            {
                return null;
            }
        }
        public async Task<CategoryDto> Create(CategoryDto item)
        {
            var cat = await FindByTitle(item.Title);
            if (cat != null)
                return cat;
            if(item.Title == "" || item.Title == null)
                return null;
            var result = await _context.Categories.AddAsync(new Category { Title = item.Title });
            await _context.SaveChangesAsync();
            if (result.Entity != null)
                return CategoryConverter.Convert((result.Entity));
            else return null;
        }
        public async Task<bool> Update(CategoryDto item)
        {
            _context.Categories.Update(CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid Id)
        {
            var prod = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == Id);
            if (prod == null)
                return false;
            _context.Categories.Remove(prod);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteByTitle(string title)
        {
            var prod = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
            if (prod == null)
                return false;
            _context.Categories.Remove(prod);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
