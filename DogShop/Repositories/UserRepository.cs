using DogShop.Data;
using DogShop.Models;

namespace DogShop.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
