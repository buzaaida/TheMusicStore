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
    public class DiscountController : ControllerBase
    {
        private IDiscountService _discountService;


        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        [Route("getAllDiscounts")]
        public async Task<ActionResult<List<Discount>>> GetAllDiscounts()
        {
            return Ok(await _discountService.GetAllDiscounts());
        }

        [HttpGet]
        [Route("getDiscountById/{id}")]
        public async Task<ActionResult<Discount>> GetDiscountById(int id)
        {
            return Ok(await _discountService.GetDiscountById(id));
        }

        [HttpPost(Name = "CreateDiscount"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Discount>> CreateDiscount(Discount discount)
        {
            return Ok(await _discountService.CreateDiscount(discount));
        }

        [HttpPut(Name = "UpdateDiscount"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Discount>> UpdateDiscount(int id)
        {
            return Ok(await _discountService.UpdateDiscount(id));
        }

        [HttpDelete(Name = "DeleteDiscount"), Authorize(Roles = "Admin")]
        public void DeleteDiscount(int id)
        {
            _discountService.DeleteDiscount(id);
        }
    }
}
