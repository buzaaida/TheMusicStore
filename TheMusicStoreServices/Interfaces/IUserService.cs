using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);

        public Task<User> UpdateUser(int id);

        public Task<IEnumerable<User>>? GetAllUsers();

        public Task<User>? GetUserById(int id);

        public void DeleteUser(int id);

        public Task<User> GetUserByEmail(string email);
    }
}
