using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IShoppingSessionRepository
    {
        public Task<ShoppingSessionEntity> CreateShoppingSession(ShoppingSessionEntity _shoppingSession);

        public Task<ShoppingSessionEntity> UpdateShoppingSession(int id);

        public Task<IEnumerable<ShoppingSessionEntity>>? GetAllShoppingSessions();

        public Task<ShoppingSessionEntity>? GetShoppingSessionById(int id);

        public void DeleteShoppingSession(int id);
    }
}
