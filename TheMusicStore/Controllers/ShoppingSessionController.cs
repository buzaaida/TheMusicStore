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
    public class ShoppingSessionController : ControllerBase
    {
        private IShoppingSessionService _shoppingSessionService;


        public ShoppingSessionController(IShoppingSessionService shoppingSessionService)
        {
            _shoppingSessionService = shoppingSessionService;
        }


        [HttpGet]
        [Route("getAllShoppingSessions")]
        public async Task<ActionResult<List<ShoppingSession>>> GetAllShoppingSessions()
        {
            return Ok(await _shoppingSessionService.GetAllShoppingSessions());
        }

        [HttpGet]
        [Route("getShoppingSessionById/{id}")]
        public async Task<ActionResult<ShoppingSession>> GetShoppingSessionById(int id)
        {
            return Ok(await _shoppingSessionService.GetShoppingSessionById(id));
        }

        [HttpPost(Name = "CreateShoppingSession"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ShoppingSession>> CreateShoppingSession(ShoppingSession shoppingSession)
        {
            return Ok(await _shoppingSessionService.CreateShoppingSession(shoppingSession));
        }

        [HttpPut(Name = "UpdateShoppingSession"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ShoppingSession>> UpdateShoppingSession(int id)
        {
            return Ok(await _shoppingSessionService.UpdateShoppingSession(id));
        }

        [HttpDelete(Name = "DeleteShoppingSession"), Authorize(Roles = "Admin")]
        public void DeleteShoppingSession(int id)
        {
            _shoppingSessionService.DeleteShoppingSession(id);
        }
    }
}
