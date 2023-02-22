using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using global::TheMusicStoreServices.Interfaces;
using global::TheMusicStoreServices.Models;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;

namespace TheMusicStoreServices.Services
{
    namespace TheMusicStoreServices.Services
    {
        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UserService(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<User> GetUserByEmail(string email)
            {
                var result = await _userRepository.GetUserByEmail(email);
                return _mapper.Map<User>(result);
            }
            public async Task<User> CreateUser(User user)
            {
                var userToAdd = _mapper.Map<UserEntity>(user);
                var result = await _userRepository.CreateUser(userToAdd);
                return _mapper.Map<User>(result);
            }

            public void DeleteUser(int id)
            {
                _userRepository.DeleteUser(id);
            }

            public async Task<User>? GetUserById(int id)
            {
                var result = await _userRepository.GetUserById(id);
                return _mapper.Map<User>(result);
                //return result.Select(user => new User()
                //{
                //    UserId = user.UserId,
                //    UserName = user.UserName,
                //    Password = user.Password,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    Address = user.Address,
                //    DateCreated = user.DateCreated,
                //    DateUpdated = user.DateUpdated,
                //    IsActive = user.IsActive,
                //});
            }

            public async Task<User> UpdateUser(int id)
            {
                var result = await _userRepository.UpdateUser(id);
                return _mapper.Map<User>(result);
            }

            public async Task<IEnumerable<User>> GetAllUsers()
            {
                var result = await _userRepository.GetAllUsers();
                return _mapper.Map<IEnumerable<User>>(result);
                //return result.Select(user => new User()
                //{
                //    UserId = user.UserId,
                //    UserName = user.UserName,
                //    Password = user.Password,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    Address = user.Address,
                //    DateCreated = user.DateCreated,
                //    DateUpdated = user.DateUpdated,
                //    IsActive = user.IsActive,
                //});
            }
        }
    }
}
