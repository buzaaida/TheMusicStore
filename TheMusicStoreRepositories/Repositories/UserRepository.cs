using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;

namespace TheMusicStoreRepositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private ApplicationDbContext _dbContext { get; set; }
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<UserEntity> CreateUser(UserEntity _user)
        {
            var result = await _dbContext.Users.AddAsync(_user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public void DeleteUser(int id)
        {
            
            var result = _dbContext.Users.FirstOrDefault(u => u.UserId == id);
            if (result != null)
            {
                _dbContext.Users.Remove(result);
                _dbContext.SaveChanges();
            }

        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserEntity>? GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<UserEntity> UpdateUser(int id)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            var _user = new UserEntity();
            if (result != null)
            {
                result.UserId = _user.UserId;
                result.UserName = _user.UserName;
                result.PasswordHash = _user.PasswordHash;
                result.PasswordSalt = _user.PasswordSalt;
                result.Token = _user.Token;
                result.TokenCreated = _user.TokenCreated;
                result.TokenExpires = _user.TokenExpires;
                result.FirstName = _user.FirstName;
                result.LastName = _user.LastName;
                result.Email = _user.Email;
                result.Address = _user.Address;
                result.DateCreated = _user.DateCreated;
                result.DateUpdated = _user.DateUpdated;
                result.IsActive = _user.IsActive;
                result.RoleId = _user.RoleId;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
