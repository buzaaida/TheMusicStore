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
    public class OrderItemRepository : IOrderItemRepository
    {

        private ApplicationDbContext _dbContext { get; set; }
        public OrderItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItemEntity> CreateOrderItem(OrderItemEntity _orderItem)
        {
            var result = await _dbContext.OrderItems.AddAsync(_orderItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteOrderItem(int id)
        {
            var result = _dbContext.OrderItems.FirstOrDefault(o => o.OrderItemId == id);
            if (result != null)
            {
                _dbContext.OrderItems.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<OrderItemEntity>> GetAllOrderItems()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItemEntity>? GetOrderItemById(int id)
        {
            return await _dbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == id); ;
        }

        public async Task<OrderItemEntity> UpdateOrderItem(int id)
        {
            var result = await _dbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == id);
            var _orderItem = new OrderItemEntity();
            if (result != null)
            {
                result.OrderItemId = _orderItem.OrderItemId;
                result.Quantity = _orderItem.Quantity;
                result.ProductId = _orderItem.ProductId;    
                result.DateCreated = _orderItem.DateCreated;
                result.DateUpdated = _orderItem.DateUpdated;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
