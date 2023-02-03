using DogShop.Models.Base;

namespace DogShop.Models
{
    public class Order: BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<AssociativeProductOrder> ProductAssociative { get; set; }

    }
}
