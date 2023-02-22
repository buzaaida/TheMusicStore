using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;
using TheMusicStoreServices.Services;

namespace TheMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private ICartItemService _cartItemService;


        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        [Route("getAllCartItems")]
        public async Task<ActionResult<List<CartItem>>> GetAllCartItems()
        {
            return Ok(await _cartItemService.GetAllCartItems());
        }

        [HttpGet]
        [Route("getCartItemById/{id}")]
        public async Task<ActionResult<CartItem>> GetCartItemById(int id)
        {
            return Ok(await _cartItemService.GetCartItemById(id));
        }

        [HttpPost(Name = "CreateCartItem"), Authorize(Roles = "User")]
        public async Task<ActionResult<CartItem>> CreateCartItem(CartItem cartItem)
        {
            return Ok(await _cartItemService.CreateCartItem(cartItem));
        }

        [HttpPut(Name = "UpdateCartItem"), Authorize(Roles = "User")]
        public async Task<ActionResult<CartItem>> UpdateCartItem(int id)
        {
            return Ok(await _cartItemService.UpdateCartItem(id));
        }

        [HttpDelete(Name = "DeleteCartItem"), Authorize(Roles = "User")]
        public void DeleteCartItem(int id)
        {
            _cartItemService.DeleteCartItem(id);
        }
    }
}
