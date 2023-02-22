using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;
using TheMusicStoreServices.Services;
using TheMusicStoreServices.Services.TheMusicStoreServices.Services;

namespace TheMusicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("getAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            return Ok(await _productService.GetAllProducts(productParameters));
        }

        [HttpGet]
        [Route("getProductById/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost(Name = "CreateProduct"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            return Ok(await _productService.CreateProduct(product));
        }

        [HttpPut(Name = "UpdateProduct"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> UpdateProduct(int id)
        {
            return Ok(await _productService.UpdateProduct(id));
        }

        [HttpDelete(Name = "DeleteProduct"), Authorize(Roles = "Admin")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}