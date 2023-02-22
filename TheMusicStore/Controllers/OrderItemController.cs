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
    public class OrderItemController : ControllerBase
    {
        private IOrderItemService _orderItemService;


        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        [Route("getAllOrderItems")]
        public async Task<ActionResult<List<OrderItem>>> GetAllOrderItems()
        {
            return Ok(await _orderItemService.GetAllOrderItems());
        }

        [HttpGet]
        [Route("getOrderItemById/{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemById(int id)
        {
            return Ok(await _orderItemService.GetOrderItemById(id));
        }

        [HttpPost(Name = "CreateOrderItem"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<OrderItem>> CreateOrderItem(OrderItem orderItem)
        {
            return Ok(await _orderItemService.CreateOrderItem(orderItem));
        }

        [HttpPut(Name = "UpdateOrderItem"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<OrderItem>> UpdateOrderItem(int id)
        {
            return Ok(await _orderItemService.UpdateOrderItem(id));
        }

        [HttpDelete(Name = "DeleteOrderItem"), Authorize(Roles = "Admin")]
        public void DeleteOrderItem(int id)
        {
            _orderItemService.DeleteOrderItem(id);
        }
    }
}
