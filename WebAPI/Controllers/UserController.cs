using Core.Entities;
using Core.Interface;
using Core.Interface.Service;
using Core.Service;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebAPI.Helpers.Attributes;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
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

        [HttpPut("Update")]
        public bool UpdateUser([FromBody] UserApiModel user)
        {
            var iUser = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Password = user.Password,
                Address = user.Address != null ? new Address()
                {
                    City = user.Address.City,
                    Country = user.Address.Country,
                    Index = user.Address.Index,
                    Street = user.Address.Street
                } : null,
            };

            return _userService.UpdateUser(iUser);
        }
    }
}
//, string? city, string? country, string? index, string? street