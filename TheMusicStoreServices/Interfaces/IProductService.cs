using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface IProductService
    {
        public Task<Product> CreateProduct(Product product);

        public Task<Product> UpdateProduct(int id);

        public Task<IEnumerable<Product>>? GetAllProducts(ProductParameters productParameters);

        public Task<Product>? GetProductById(int id);

        public void DeleteProduct(int id);
    }
}
