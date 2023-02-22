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
    public class DiscountService : IDiscountService
    {

        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }
        public async Task<Discount> CreateDiscount(Discount discount)
        {
            var discountToAdd = _mapper.Map<DiscountEntity>(discount);
            var result = await _discountRepository.CreateDiscount(discountToAdd);
            return _mapper.Map<Discount>(result);
        }

        public void DeleteDiscount(int id)
        {
            _discountRepository.DeleteDiscount(id);
        }

        public async Task<IEnumerable<Discount>>? GetAllDiscounts()
        {
            var result = await _discountRepository.GetAllDiscounts();
            return _mapper.Map<IEnumerable<Discount>>(result);
        }

        public async Task<Discount>? GetDiscountById(int id)
        {
            var result = await _discountRepository.GetDiscountById(id);
            return _mapper.Map<Discount>(result);
        }

        public async Task<Discount> UpdateDiscount(int id)
        {
            var result = await _discountRepository.UpdateDiscount(id);
            return _mapper.Map<Discount>(result);
        }
    }
}
