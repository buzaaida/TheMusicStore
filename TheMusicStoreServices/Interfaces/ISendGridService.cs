using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Interfaces
{
    public interface ISendGridService
    {
        public void SendMail(int userId, int orderId);
    }
}
