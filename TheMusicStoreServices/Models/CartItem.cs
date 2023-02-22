using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicStoreServices.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public User UserId { get; set; }
        public OrderItem OrderItemId { get; set; }  
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
