using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<OrderEntity> CreateOrder(OrderEntity _order);

        public Task<OrderEntity> UpdateOrder(int id);

        public Task<IEnumerable<OrderEntity>>? GetAllOrders();

        public Task<OrderEntity>? GetOrderById(int id);

        public void DeleteOrder(int id);
    }
}
