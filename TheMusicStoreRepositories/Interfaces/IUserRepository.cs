using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IUserRepository
    {

        public Task<UserEntity> CreateUser(UserEntity _user);

        public Task<UserEntity> UpdateUser(int id);

        public Task<IEnumerable<UserEntity>>? GetAllUsers();

        public Task<UserEntity>? GetUserById(int id);

        public void DeleteUser(int id);
        public Task<UserEntity> GetUserByEmail(string email);
    }
}
