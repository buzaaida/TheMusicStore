using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;

namespace TheMusicStoreRepositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<RoleEntity> GetAllRoles();
    }
}
