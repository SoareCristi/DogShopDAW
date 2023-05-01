using DogShop.Models;

namespace DogShop.Services
{
    public interface IUserService
    {
        Task Create(User newUser);
        Task Delete(User userToDelete);
    }
}
