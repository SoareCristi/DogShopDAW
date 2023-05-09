using DogShop.Models.Base;
using Newtonsoft.Json;

namespace DogShop.Models
{
    public class Wishlist : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public ICollection<AssociativeProductWishlist> ProductAssociative { get; set; }

    }
}
