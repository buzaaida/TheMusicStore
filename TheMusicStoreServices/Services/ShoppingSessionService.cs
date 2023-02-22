using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;
using TheMusicStoreRepositories.Repositories;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Services
{
    public class ShoppingSessionService : IShoppingSessionService
    {
        private readonly IShoppingSessionRepository _shoppingSessionRepository;
        private readonly IMapper _mapper;

        public ShoppingSessionService(IShoppingSessionRepository shoppingSessionRepository, IMapper mapper)
        {
            _shoppingSessionRepository = shoppingSessionRepository;
            _mapper = mapper;
        }


        public async Task<ShoppingSession> CreateShoppingSession(ShoppingSession shoppingSession)
        {
            var shoppingSessionToAdd = _mapper.Map<ShoppingSessionEntity>(shoppingSession);
            var result = await _shoppingSessionRepository.CreateShoppingSession(shoppingSessionToAdd);
            return _mapper.Map<ShoppingSession>(result);
        }

        public void DeleteShoppingSession(int id)
        {
            _shoppingSessionRepository.DeleteShoppingSession(id);
        }

        public async Task<IEnumerable<ShoppingSession>>? GetAllShoppingSessions()
        {
            var result = await _shoppingSessionRepository.GetAllShoppingSessions();
            return _mapper.Map<IEnumerable<ShoppingSession>>(result);
        }

        public async Task<ShoppingSession>? GetShoppingSessionById(int id)
        {
            var result = await _shoppingSessionRepository.GetShoppingSessionById(id);
            return _mapper.Map<ShoppingSession>(result);
        }

        public async Task<ShoppingSession> UpdateShoppingSession(int id)
        {
            var result = await _shoppingSessionRepository.UpdateShoppingSession(id);
            return _mapper.Map<ShoppingSession>(result);
        }
    }
}
