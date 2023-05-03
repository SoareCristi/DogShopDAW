using System.ComponentModel.DataAnnotations;

namespace DogShop.Models.DTO
{
    public class WishlistRequestDTO
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
