using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface IDiscountService
    {
        public Task<Discount> CreateDiscount(Discount discount);

        public Task<Discount> UpdateDiscount(int id);

        public Task<IEnumerable<Discount>>? GetAllDiscounts();

        public Task<Discount>? GetDiscountById(int id);

        public void DeleteDiscount(int id);
    }
}
