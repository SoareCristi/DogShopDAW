using DogShop.Models;

namespace DogShop.Services
{
    public interface IWishlistService
    {
        Task Create(Wishlist wishlist);
        Task Delete(Wishlist wishlist);
        Wishlist GetById(Guid id);
        bool Save();
        Task Update(Wishlist updateWishlist);
    }
}