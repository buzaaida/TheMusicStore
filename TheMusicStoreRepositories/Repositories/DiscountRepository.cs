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
    public class DiscountRepository : IDiscountRepository
    {

        private ApplicationDbContext _dbContext { get; set; }
        public DiscountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DiscountEntity> CreateDiscount(DiscountEntity _discount)
        {
            var result = await _dbContext.Discounts.AddAsync(_discount);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteDiscount(int id)
        {
            var result = _dbContext.Discounts.FirstOrDefault(d => d.DiscountId == id);
            if (result != null)
            {
                _dbContext.Discounts.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<DiscountEntity>>? GetAllDiscounts()
        {
            return await _dbContext.Discounts.ToListAsync();
        }

        public async Task<DiscountEntity>? GetDiscountById(int id)
        {
            return await _dbContext.Discounts.FirstOrDefaultAsync(d => d.DiscountId == id);
        }

        public async Task<DiscountEntity> UpdateDiscount(int id)
        {
            var result = await _dbContext.Discounts.FirstOrDefaultAsync(d => d.DiscountId == id);
            var _discount = new DiscountEntity();
            if (result != null)
            {
                result.DiscountId = _discount.DiscountId;
                result.Name = _discount.Name;
                result.Percent = _discount.Percent;
                result.DateCreated = _discount.DateCreated;
                result.DateUpdated = _discount.DateUpdated;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
