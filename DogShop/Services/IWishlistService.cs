using DogShop.Models;

namespace DogShop.Services
{
    public interface IWishlistService
    {
        Task Create(Wishlist wishlist);
        Task Delete(Wishlist wishlist);

    }
}