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

            return Ok(user.Id);
        }


        [HttpPost("CreateWebAdmin")]
        public async Task<IActionResult> CreateWebAdmin(UserRequestDTO newUser)
        {
            var user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                DateCreated = DateTime.Now,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = Roles.WebAdmin
            };
            await _userService.Create(user);
            Console.WriteLine(user.Id);
            return Ok();
        }


        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO newUser)
        {
            var user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                DateCreated = DateTime.Now,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = Roles.Admin
            };
            await _userService.Create(user);
            Console.WriteLine(user.Id);
            return Ok();
        }


        [HttpPost("Authentificate")]
        public async Task<IActionResult> Authentificate(UserRequestDTO user)
        {
            var response = _userService.Authentificate(user);
            if (response == null)
            {
                return NotFound("Username or password is invalid!");
            }
            return Ok(response);//mod
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequestDTO updateUser)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound("Id not found");
            }
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUser.Password);
            user.DateModified = DateTime.Now;
            _userService.Save();
            return Ok();
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
     
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{id}")]
        //[Authorization(Roles.WebAdmin, Roles.Admin)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.Delete(user);
            _userService.Save();
            return Ok();
        }

    }
}
