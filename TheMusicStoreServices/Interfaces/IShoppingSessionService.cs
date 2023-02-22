using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface IShoppingSessionService
    {
        public Task<ShoppingSession> CreateShoppingSession(ShoppingSession shoppingSession);

        public Task<ShoppingSession> UpdateShoppingSession(int id);

        public Task<IEnumerable<ShoppingSession>>? GetAllShoppingSessions();

        public Task<ShoppingSession>? GetShoppingSessionById(int id);

        public void DeleteShoppingSession(int id);
    }
}
