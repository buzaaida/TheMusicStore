using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Entities;
using TheMusicStoreRepositories.Interfaces;

namespace TheMusicStoreRepositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<RoleEntity> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
