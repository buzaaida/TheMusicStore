using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMusicStoreRepositories.Entities
{
    public class ShoppingSessionEntity
    {
        [Key]
        public int ShoppingSessionId { get; set; }
        public double Total { get; set; }
        [JsonIgnore]
        public IEnumerable<OrderEntity>? Orders { get; set; }
        public UserEntity UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
