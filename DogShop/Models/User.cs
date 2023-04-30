using DogShop.Models.Base;
using System.Data;
using System.Text.Json.Serialization;
using DogShop.Helper;

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

        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }
    }
}
