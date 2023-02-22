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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            //var result = new Order();
            //return _mapper.Map<Order>(result);

            var orderToAdd = _mapper.Map<OrderEntity>(order);
            var result = await _orderRepository.CreateOrder(orderToAdd);
            return _mapper.Map<Order>(result);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }

        public async Task<IEnumerable<Order>>? GetAllOrders()
        {
            var result = await _orderRepository.GetAllOrders();
            return _mapper.Map<IEnumerable<Order>>(result);
        }

        public async Task<Order>? GetOrderById(int id)
        {
            var result = await _orderRepository.GetOrderById(id);
            return _mapper.Map<Order>(result);
        }

        public async Task<Order> UpdateOrder(int id)
        {
            var result = await _orderRepository.UpdateOrder(id);
            return _mapper.Map<Order>(result);
        }
    }
}
