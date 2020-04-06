using OnlineShop.DOMAIN.Dto;
using OnlineShop.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DOMAIN.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> GetById(Guid Id);
        Task<List<ProductDto>> FindByName(string name);
        Task<ProductDto> Create(string title, string description, decimal cost, Guid Category, string path);
        Task<bool> Update(ProductDto item);
        Task<bool> Delete(Guid Id);
        Task<ProductDto> FindCategory(Product product);
        Task<List<ProductDto>> FindByCategory(Guid title);
        Task<List<ProductDto>> FindCategory(List<Product> products);
    }
}
