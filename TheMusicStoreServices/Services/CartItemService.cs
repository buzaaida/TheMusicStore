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
    public class CartItemService : ICartItemService
    {

        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<CartItem> CreateCartItem(CartItem cartItem)
        {
            var cartItemToAdd = _mapper.Map<CartItemEntity>(cartItem);
            var result = await _cartItemRepository.CreateCartItem(cartItemToAdd);
            return _mapper.Map<CartItem>(result);
        }

        public void DeleteCartItem(int id)
        {
            _cartItemRepository.DeleteCartItem(id);
        }

        public async Task<IEnumerable<CartItem>>? GetAllCartItems()
        {
            var result = await _cartItemRepository.GetAllCartItems();
            return _mapper.Map<IEnumerable<CartItem>>(result);
        }

        public async Task<CartItem>? GetCartItemById(int id)
        {
            var result = await _cartItemRepository.GetCartItemById(id);
            return _mapper.Map<CartItem>(result);
        }

        public async Task<CartItem> UpdateCartItem(int id)
        {
            var result = await _cartItemRepository.UpdateCartItem(id);
            return _mapper.Map<CartItem>(result);
        }
    }
}
