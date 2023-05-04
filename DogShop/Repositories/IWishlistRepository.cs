using DogShop.Models;

namespace DogShop.Repositories
{
    public interface IWishlistRepository: IGenericRepository<Wishlist>
    {
        IEnumerable<IGrouping<Guid, dynamic>> GetAllWishlistsWithProducts();
    }
}