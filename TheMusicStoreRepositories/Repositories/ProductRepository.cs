using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;
using TheMusicStoreServices.Models;

namespace TheMusicStoreRepositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _dbContext { get; set; }
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductEntity> CreateProduct(ProductEntity _product)
        {
            var result = await _dbContext.Products.AddAsync(_product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductEntity> UpdateProduct(int id)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            var _product = new ProductEntity();
            if (result != null)
            {
                result.ProductId = _product.ProductId;
                result.Name = _product.Name;
                result.Category = _product.Category;
                result.Brand = _product.Brand;
                result.Color = _product.Color;
                result.Popularity = _product.Popularity;
                result.Description = _product.Description;
                result.Available = _product.Available;
                result.Price = _product.Price;
                result.DateCreated = _product.DateCreated;
                result.DateUpdated = _product.DateUpdated;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ProductEntity>>? GetAllProducts(ProductParameters productParameters)
        {
            return  _dbContext.Products.OrderBy(p => p.Name)
        .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
        .Take(productParameters.PageSize)
        .ToList();
        }



        public async Task<ProductEntity>? GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public void DeleteProduct(int id)
        {
            var result = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (result != null)
            {
                _dbContext.Products.Remove(result);
                _dbContext.SaveChanges();
            }
        }
    }
}
