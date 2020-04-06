using OnlineShop.DOMAIN.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DOMAIN.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(Guid Id);
        Task<CategoryDto> FindByTitle(string title);
        Task<CategoryDto> Create(CategoryDto item);
        Task<bool> Update(CategoryDto item);
        Task<bool> Delete(Guid Id);
        Task<bool> DeleteByTitle(string title);
    }
}
