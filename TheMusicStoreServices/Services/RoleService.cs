using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Services
{
    public class RoleService : IRoleService
    {

        IEnumerable<Role> IRoleService.GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
