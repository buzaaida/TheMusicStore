using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;
using TheMusicStoreServices.Services;

namespace TheMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("getAllOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }

        [HttpGet]
        [Route("getOrderById/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            return Ok(await _orderService.GetOrderById(id));
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            return Ok(await _orderService.CreateOrder(order));
        }

        [HttpPut(Name = "UpdateOrder")]
        public async Task<ActionResult<Order>> UpdateOrder(int id)
        {
            return Ok(await _orderService.UpdateOrder(id));
        }

        [HttpDelete(Name = "DeleteOrder")]
        public void DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}
