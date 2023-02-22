using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMusicStoreRepositories.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public string Token { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public RoleEntity RoleId { get; set; }
        [JsonIgnore]
        public IEnumerable<OrderItemEntity>? Products { get; set; }
    }
}
