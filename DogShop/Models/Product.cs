using DogShop.Models.Base;
using System.Text.Json.Serialization;

namespace DogShop.Models
{
    public class Product : BaseEntity
    {
        public int Price { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<AssociativeProductOrder> OrderAssociative { get; set; }
        [JsonIgnore]
        public ICollection<AssociativeProductWishlist> WishlistAssociative { get; set; }

    }
}
