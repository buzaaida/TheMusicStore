using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> CreateOrder(Order order);

        public Task<Order> UpdateOrder(int id);

        public Task<IEnumerable<Order>>? GetAllOrders();

        public Task<Order>? GetOrderById(int id);

        public void DeleteOrder(int id);
    }
}
