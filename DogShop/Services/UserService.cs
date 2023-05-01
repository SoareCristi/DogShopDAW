using DogShop.Helper;
using DogShop.Models;
using DogShop.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;


namespace DogShop.Services
{
    public class UserService: IUserService
    {
        public IUserRepository _userRepo;
        public IJwtUtils _jwtUtils;
        
        public UserService(IUserRepository userRepo, IJwtUtils jwtUtils)
        {
            _userRepo = userRepo;
            _jwtUtils = jwtUtils;
        }

        public async Task Create(User user)
        {
            await _userRepo.CreateAsync(user);
            await _userRepo.SaveAsync();
        }

        public async Task Delete(User user)
        {
            _userRepo.Delete(user);
            await _userRepo.SaveAsync();
        }

    }


}
