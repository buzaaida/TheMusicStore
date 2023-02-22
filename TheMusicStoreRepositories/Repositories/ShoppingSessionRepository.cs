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
    public class ShoppingSessionRepository : IShoppingSessionRepository
    {
        private ApplicationDbContext _dbContext { get; set; }
        public ShoppingSessionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ShoppingSessionEntity> CreateShoppingSession(ShoppingSessionEntity _shoppingSession)
        {
            var result = await _dbContext.ShoppingSessions.AddAsync(_shoppingSession);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteShoppingSession(int id)
        {
            var result = _dbContext.ShoppingSessions.FirstOrDefault(s => s.ShoppingSessionId == id);
            if (result != null)
            {
                _dbContext.ShoppingSessions.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<ShoppingSessionEntity>>? GetAllShoppingSessions()
        {
            return await _dbContext.ShoppingSessions.ToListAsync();
        }

        public async Task<ShoppingSessionEntity>? GetShoppingSessionById(int id)
        {
            return await _dbContext.ShoppingSessions.FirstOrDefaultAsync(s => s.ShoppingSessionId == id);
        }

        public async Task<ShoppingSessionEntity> UpdateShoppingSession(int id)
        {
            var result = await _dbContext.ShoppingSessions.FirstOrDefaultAsync(s => s.ShoppingSessionId == id);
            var _shoppingSession = new ShoppingSessionEntity();
            if (result != null)
            {
                result.ShoppingSessionId = _shoppingSession.ShoppingSessionId;
                result.Total = result.Total;
                result.UserId = _shoppingSession.UserId;
                result.DateCreated = _shoppingSession.DateCreated;
                result.DateUpdated = _shoppingSession.DateUpdated;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
