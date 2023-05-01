using DogShop.Data;
using DogShop.Models;

namespace DogShop.Repositories
{
    public class WishlistRepository: GenericRepository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(Context context) : base(context)
        {
        }

    }
}
