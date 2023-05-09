using DogShop.Data;
using DogShop.Helper;
using DogShop.Models;
using DogShop.Repositories;

namespace DogShop.Services
{
    public class WishlistService: IWishlistService
    {
        public IWishlistRepository _wishlistRepo;
        public IUnitOfWork _unitOfWork;

        public WishlistService(IWishlistRepository wishlistRepo, IUnitOfWork unitOfWork)
        {
            _wishlistRepo = wishlistRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Wishlist wishlist)
        {
            await _wishlistRepo.CreateAsync(wishlist);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(Wishlist wishlist)
        {
            _wishlistRepo.Delete(wishlist);
            await _unitOfWork.SaveAsync();
        }

        public Wishlist GetById(Guid id)
        {
            return _wishlistRepo.FindById(id);
        }
        public async Task Save()
        {
            await _unitOfWork.SaveAsync();// _wishlistRepo.Save();
        }
        public async Task Update(Wishlist updateWishlist)
        {
            _wishlistRepo.Update(updateWishlist);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<IGrouping<Guid, dynamic>> GetAllWishlistsWithProducts()
        {
            return _wishlistRepo.GetAllWishlistsWithProducts();
        }

        public IQueryable<AssociativeProductWishlist> WishlistsWithProducts()
        {
            return _wishlistRepo.WishlistsWithProducts();
        }
    }
}
