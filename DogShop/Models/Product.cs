using DogShop.Models.Base;

namespace DogShop.Models
{
    public class Product : BaseEntity
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public ICollection<AssociativeProductOrder> OrderAssociative { get; set; }
        public ICollection<AssociativeProductWishlist> WishlistAssociative { get; set; }

    }
}
