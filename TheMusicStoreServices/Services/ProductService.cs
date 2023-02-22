using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;
using TheMusicStoreRepositories.Repositories;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            //var result = new Product();
            //return _mapper.Map<Product>(result);

            var productToAdd = _mapper.Map<ProductEntity>(product);
            var result = await _productRepository.CreateProduct(productToAdd);
            return _mapper.Map<Product>(result);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<Product>>? GetAllProducts(ProductParameters productParameters)
        {
            var result = await _productRepository.GetAllProducts(productParameters);
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public async Task<Product>? GetProductById(int id)
        {
            var result = await _productRepository.GetProductById(id);
            return _mapper.Map<Product>(result);
        }

        public async Task<Product> UpdateProduct(int id)
        {
            var result = await _productRepository.UpdateProduct(id);
            return _mapper.Map<Product>(result);
        }
    }
}
