using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IDiscountRepository
    {
        public Task<DiscountEntity> CreateDiscount(DiscountEntity _discount);

        public Task<DiscountEntity> UpdateDiscount(int id);

        public Task<IEnumerable<DiscountEntity>>? GetAllDiscounts();

        public Task<DiscountEntity>? GetDiscountById(int id);

        public void DeleteDiscount(int id);
    }
}
