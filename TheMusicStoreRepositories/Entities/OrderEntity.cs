using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicStoreRepositories.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }
        public UserEntity UserId { get; set; }
        public OrderItemEntity OrderItemId { get; set; }
        public double Total { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
