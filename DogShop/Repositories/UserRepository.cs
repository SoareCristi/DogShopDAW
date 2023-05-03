using DogShop.Data;
using DogShop.Models;

namespace DogShop.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public User FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
    }
}
