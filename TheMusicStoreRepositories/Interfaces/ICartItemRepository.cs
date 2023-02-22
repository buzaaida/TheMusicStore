using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface ICartItemRepository
    {
        public Task<CartItemEntity> CreateCartItem(CartItemEntity _cartItem);

        public Task<CartItemEntity> UpdateCartItem(int id);

        public Task<IEnumerable<CartItemEntity>>? GetAllCartItems();

        public Task<CartItemEntity>? GetCartItemById(int id);

        public void DeleteCartItem(int id);
    }
}
