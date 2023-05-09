using DogShop.Models;
using DogShop.Models.DTO;

namespace DogShop.Services
{
    public interface IUserService
    {
        Task Create(User newUser);
        Task Delete(User userToDelete);
        Task Update(User updateUser);
        User GetById(Guid id);
        Task Save();
        UserResponseDTO Authentificate(UserRequestDTO model);
        List<User> GetAllUsers();
        User GetByEmail(string email);
    }
}
