using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext (DbContextOptions options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<DiscountEntity> Discounts { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }
        public DbSet<ShoppingSessionEntity> ShoppingSessions { get; set; }

    }
}
