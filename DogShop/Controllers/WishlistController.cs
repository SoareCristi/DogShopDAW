using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogShop.Models;
using DogShop.Models.DTO;
using DogShop.Services;

namespace DogShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;
        private readonly IUserService _userService;

        public WishlistController(IWishlistService wishlistService, IUserService userService)
        {
            _wishlistService = wishlistService;
            _userService = userService;
        }

        [HttpPost("CreateWishlist")]
        public async Task<IActionResult> CreateWishlist(WishlistRequestDTO newWishlist)
        {
            var wishlist = new Wishlist
            {
                UserId = newWishlist.UserId,
                DateCreated = DateTime.Now,
            };

            var user = _userService.GetById(wishlist.UserId);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            await _wishlistService.Create(wishlist);
            Console.WriteLine(wishlist.Id);
            return Ok();
        }

    }
}
