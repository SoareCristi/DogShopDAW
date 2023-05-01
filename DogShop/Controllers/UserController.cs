using DogShop.Helper;
using DogShop.Models;
using DogShop.Models.DTO;
using DogShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogShop.Controllers
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

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserRequestDTO newUser)
        {
            var user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                DateCreated = DateTime.Now,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = Roles.User
            };

            await _userService.Create(user);

            Console.WriteLine(user.Id);

            return Ok();
        }

    }
}
