using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Interfaces;

namespace TheMusicStoreRepositories.Repositories
{
    internal class ShoppingCartRepository 
    {
        private ApplicationDbContext _dbContext { get; set; }
        public ShoppingCartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //public void AddToCart(int id)
        //{

        //    var cartItem = _dbContext.CartItems.SingleOrDefault(
        //        c => c.CartItemId == id
        //        && c.OrderItemId == id);
        //    if (cartItem == null)
        //    {
        //        cartItem = new CartItem
        //        {
        //            CartItemId = Guid.NewGuid().ToString(),
        //            OrdedrItemId = id,
        //            CartItemId = CartItemId,
        //            Product = _dbContext.OrderItems.SingleOrDefault(
        //           o => o.OrderItem == id),
        //            Quantity = 1,
        //            DateCreated = DateTime.Now
        //        };

        //        _dbContext.CartItems.Add(cartItem);
        //    }
        //    else
        //    {
                                 
        //        cartItem.Quantity++;
        //    }
        //    _dbContext.SaveChanges();
        //}
    }
}
