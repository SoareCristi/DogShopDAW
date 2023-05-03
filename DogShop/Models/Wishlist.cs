using DogShop.Models.Base;

namespace DogShop.Models
{
    public class Wishlist : BaseEntity
    {

        public ICollection<AssociativeProductWishlist> ProductAssociative { get; set; }

    }
}
