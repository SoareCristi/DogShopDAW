using DogShop.Helper;
using DogShop.Models;
using DogShop.Repositories;

namespace DogShop.Services
{
    public class WishlistService: IWishlistService
    {
        public IWishlistRepository _wishlistRepo;

        public WishlistService(IWishlistRepository wishlistRepo)
        {
            _wishlistRepo = wishlistRepo;
        }

        public async Task Create(Wishlist wishlist)
        {
            await _wishlistRepo.CreateAsync(wishlist);
            await _wishlistRepo.SaveAsync();
        }

        public async Task Delete(Wishlist wishlist)
        {
            _wishlistRepo.Delete(wishlist);
            await _wishlistRepo.SaveAsync();
        }

        public Wishlist GetById(Guid id)
        {
            return _wishlistRepo.FindById(id);
        }
        public bool Save()
        {
            return _wishlistRepo.Save();
        }
        public async Task Update(Wishlist updateWishlist)
        {
            _wishlistRepo.Update(updateWishlist);
            await _wishlistRepo.SaveAsync();
        }


    }
}
