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
    public class CartItemRepository : ICartItemRepository
    {

        private ApplicationDbContext _dbContext { get; set; }
        public CartItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CartItemEntity> CreateCartItem(CartItemEntity _cartItem)
        {
            var result = await _dbContext.CartItems.AddAsync(_cartItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteCartItem(int id)
        {
            var result = _dbContext.CartItems.FirstOrDefault(c => c.CartItemId == id);
            if (result != null)
            {
                _dbContext.CartItems.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<CartItemEntity>>? GetAllCartItems()
        {
            return await _dbContext.CartItems.ToListAsync();
        }

        public async Task<CartItemEntity>? GetCartItemById(int id)
        {
            return await _dbContext.CartItems.FirstOrDefaultAsync(c => c.CartItemId == id);
        }

        public async Task<CartItemEntity> UpdateCartItem(int id)
        {
            var result = await _dbContext.CartItems.FirstOrDefaultAsync(c => c.CartItemId == id);
            var _cartItem = new CartItemEntity();
            if (result != null)
            {
                result.CartItemId = _cartItem.CartItemId;
                result.UserId = _cartItem.UserId;
                result.OrderItemId = _cartItem.OrderItemId;
                result.DateCreated = _cartItem.DateCreated;
                result.DateUpdated = _cartItem.DateUpdated;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
