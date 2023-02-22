using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IOrderItemRepository
    {
        public Task<OrderItemEntity> CreateOrderItem(OrderItemEntity _orderItem);

        public Task<OrderItemEntity> UpdateOrderItem(int id);

        public Task<IEnumerable<OrderItemEntity>>? GetAllOrderItems();

        public Task<OrderItemEntity>? GetOrderItemById(int id);

        public void DeleteOrderItem(int id);
    }
}
