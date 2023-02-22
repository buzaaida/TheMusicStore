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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getAllUsers"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            return Ok(await _userService.CreateUser(user));
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<ActionResult<User>> UpdateUser(int id)
        {
            return Ok( await _userService.UpdateUser(id));
        }

        [HttpDelete(Name = "DeleteUser")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }

    }
}
