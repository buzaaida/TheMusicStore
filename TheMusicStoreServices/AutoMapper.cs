using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Product, ProductEntity>().ReverseMap();
            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<OrderItem, OrderEntity>().ReverseMap();
            CreateMap<CartItem, CartItemEntity>().ReverseMap();
            CreateMap<Role, RoleEntity>().ReverseMap();
        }
    }
}
