using DogShop.Repositories;

namespace DogShop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IWishlistRepository WishlistRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        private Context _context { get; set; }

        public UnitOfWork(Context context, IWishlistRepository wishlistRepository, IUserRepository userRepository)
        {
            _context = context;
            WishlistRepository = wishlistRepository;
            UserRepository = userRepository;

        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() != 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
