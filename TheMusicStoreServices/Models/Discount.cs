using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMusicStoreServices.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
