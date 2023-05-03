using DogShop.Models.Base;

namespace DogShop.Models
{
    public class Wishlist : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<AssociativeProductWishlist> ProductAssociative { get; set; }

    }
}
