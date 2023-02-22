using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface ICartItemService
    {
        public Task<CartItem> CreateCartItem(CartItem cartItem);

        public Task<CartItem> UpdateCartItem(int id);

        public Task<IEnumerable<CartItem>>? GetAllCartItems();

        public Task<CartItem>? GetCartItemById(int id);

        public void DeleteCartItem(int id);
    }
}
