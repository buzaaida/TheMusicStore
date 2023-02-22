using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreServices.Models;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<ProductEntity> CreateProduct(ProductEntity _product);

        public Task<ProductEntity> UpdateProduct(int id);

        public Task<IEnumerable<ProductEntity>>? GetAllProducts(ProductParameters productParameters);

        public Task<ProductEntity>? GetProductById(int id);

        public void DeleteProduct(int id);
    }
}
