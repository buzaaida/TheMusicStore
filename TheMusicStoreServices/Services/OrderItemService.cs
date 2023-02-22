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
    public class OrderItemService : IOrderItemService
    {

        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            var orderItemToAdd = _mapper.Map<OrderItemEntity>(orderItem);
            var result = await _orderItemRepository.CreateOrderItem(orderItemToAdd);
            return _mapper.Map<OrderItem>(result);
        }

        public void DeleteOrderItem(int id)
        {
            _orderItemRepository.DeleteOrderItem(id);
        }

        public async Task<IEnumerable<OrderItem>>? GetAllOrderItems()
        {
            var result = await _orderItemRepository.GetAllOrderItems();
            return _mapper.Map<IEnumerable<OrderItem>>(result);
        }

        public async Task<OrderItem>? GetOrderItemById(int id)
        {
            var result = await _orderItemRepository.GetOrderItemById(id);
            return _mapper.Map<OrderItem>(result);
        }

        public async Task<OrderItem> UpdateOrderItem(int id)
        {
            var result = await _orderItemRepository.UpdateOrderItem(id);
            return _mapper.Map<OrderItem>(result);
        }
    }
}
