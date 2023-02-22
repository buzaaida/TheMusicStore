using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;

namespace TheMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;


        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet(Name = "GetAllRoles"), Authorize(Roles = "User")]
        public IEnumerable<Role> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }
    }
}
