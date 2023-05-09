using DogShop.Data;
using DogShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DogShop.Repositories
{
    public class WishlistRepository: GenericRepository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(Context context) : base(context)
        {
        }

        public IEnumerable<IGrouping<Guid, dynamic>>  GetAllWishlistsWithProducts()
        {
            var wishlistsWithProducts = _context.AssociativeProductWishlists
                .Join(_context.Products,
                    apw => apw.ProductId,
                    p => p.Id,
                    (apw, p) => new { apw.WishlistId, apw.ProductId, p.Price, p.Name })
                .Join(_context.Wishlists,
                    res => res.WishlistId,
                    w => w.Id,
                    (res, w) => new
                    {
                        res.WishlistId,
                        w.UserId,
                        res.ProductId,
                        res.Price,
                        res.Name,
                    })
                .Where(x => x.Price > 50)
                .GroupBy(x => new
                    {
                        x.WishlistId,
                        x.UserId,    
                        x.ProductId, 
                        x.Price,
                        x.Name
                    })
                .Select(g => new
                {
                    WishlistId = g.Key.WishlistId,
                    UserId = g.Key.UserId,
                    ProductId = g.Key.ProductId,
                    Name = g.Key.Name,
                    Price = g.Key.Price
                });
            return wishlistsWithProducts.GroupBy(g => g.WishlistId);
        }

        public IQueryable<AssociativeProductWishlist> WishlistsWithProducts()
        {
            return _context.AssociativeProductWishlists
                .Include(apw => apw.Product);
        }

    }
}
