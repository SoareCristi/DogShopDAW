using DogShop.Models;

namespace DogShop.Services
{
    public interface IWishlistService
    {
        Task Create(Wishlist wishlist);
        Task Delete(Wishlist wishlist);
        Wishlist GetById(Guid id);
        Task Save();
        Task Update(Wishlist updateWishlist);
        IEnumerable<IGrouping<Guid, dynamic>> GetAllWishlistsWithProducts();
        IQueryable<AssociativeProductWishlist> WishlistsWithProducts();
    }
}