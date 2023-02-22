using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface IOrderItemService
    {
        public Task<OrderItem> CreateOrderItem(OrderItem orderItem);

        public Task<OrderItem> UpdateOrderItem(int id);

        public Task<IEnumerable<OrderItem>>? GetAllOrderItems();

        public Task<OrderItem>? GetOrderItemById(int id);

        public void DeleteOrderItem(int id);
    }
}
