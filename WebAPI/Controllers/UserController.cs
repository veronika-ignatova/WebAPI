using Core.Entities;
using Core.Interface;
using Core.Interface.Service;
using Core.Service;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<IUser> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public IUser GetUser(Guid id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("email/{email}")]
        public IUser GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }

        [HttpPatch("Update/{id}")]
        public bool UpdateUserById([FromRoute] Guid id, [FromBody] string? name, int? age, string? password)
        {
            var user = new User()
            {
                Id = id,
                Name = name,
                Age = age,
                Password = password
            };
            return _userService.UpdateUser(user);
        }
    }
}
//, string? city, string? country, string? index, string? street