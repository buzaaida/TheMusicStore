using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;

namespace TheMusicStoreRepositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _dbContext { get; set; }
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderEntity> CreateOrder(OrderEntity _order)
        {
            var result = await _dbContext.Orders.AddAsync(_order);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<OrderEntity> UpdateOrder(int id)
        {
            var result = await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            var _order = new OrderEntity();
            if (result != null)
            {
                result.OrderId = _order.OrderId;
                result.Total = _order.Total;
                result.DateCreated = _order.DateCreated;
                result.DateUpdated = _order.DateUpdated;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<OrderEntity>>? GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrderEntity>? GetOrderById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public void DeleteOrder(int id)
        {
            var result = _dbContext.Orders.FirstOrDefault(p => p.OrderId == id);
            if (result != null)
            {
                _dbContext.Orders.Remove(result);
                _dbContext.SaveChanges();
            }
        }
    }
}
