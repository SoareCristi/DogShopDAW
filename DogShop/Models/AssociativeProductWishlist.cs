namespace DogShop.Models
{
    public class AssociativeProductWishlist
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
