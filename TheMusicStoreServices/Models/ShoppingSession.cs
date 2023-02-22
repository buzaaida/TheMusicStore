using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreServices.Models
{
    public class ShoppingSession
    {
        public int ShoppingSessionId { get; set; }
        public double Total { get; set; }
        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; }
        public User UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
