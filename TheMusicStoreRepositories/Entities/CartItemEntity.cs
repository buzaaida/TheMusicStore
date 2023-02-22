using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicStoreRepositories.Entities
{
    public class CartItemEntity
    {
        [Key]
        public int CartItemId { get; set; }
        public UserEntity UserId { get; set; }
        public OrderItemEntity OrderItemId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
