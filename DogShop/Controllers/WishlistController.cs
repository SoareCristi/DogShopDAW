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

        [HttpPut("UpdateWishlist/{id}")]
        public async Task<IActionResult> UpdateWishlist(Guid id, [FromBody] WishlistRequestDTO updateWishlist)
        {
            var wishlist = _wishlistService.GetById(id);
            if (wishlist == null)
            {
                return BadRequest("Wishlist does not exist");
            }
            wishlist.UserId = updateWishlist.UserId;
            wishlist.DateModified = DateTime.Now;
            await _wishlistService.Update(wishlist);
            return Ok();
        }


        [HttpGet("GetWishlistById/{id}")]
        public async Task<IActionResult> GetWishlistById(Guid id)
        {
            var wishlist = _wishlistService.GetById(id);
            if (wishlist == null)
            {
                return NotFound();//BadRequest("Wishlist does not exist");
            }
            return Ok(wishlist);
        }

        //async task to delete wishlist by id
        [HttpDelete("DeleteWishlist/{id}")]
        public async Task<IActionResult> DeleteWishlist(Guid id)
        {
            var wishlist = _wishlistService.GetById(id);
            if (wishlist == null)
            {
                return BadRequest("Wishlist does not exist");
            }
            await _wishlistService.Delete(wishlist);
            _wishlistService.Save();
            return Ok();
        }

    }
}
