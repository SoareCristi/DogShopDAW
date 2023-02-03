using DogShop.Models.Base;

namespace DogShop.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Wishlist Wishlist { get; set; }
        public Guid WishlistId { get; set; }

        public ICollection<Order> OrderList { get; set; }
    }
}
