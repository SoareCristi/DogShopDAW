using DogShop.Data;
using DogShop.Helper;
using DogShop.Models;
using DogShop.Models.DTO;
using DogShop.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;


namespace DogShop.Services
{
    public class UserService: IUserService
    {
        public IUserRepository _userRepo;
        public IJwtUtils _jwtUtils;
        public IUnitOfWork _unitOfWork;

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

        public User GetById(Guid id)
        {
            return _userRepo.FindById(id);
        }

        public bool Save()
        {
            return _userRepo.Save();
        }

        public async Task Update(User updateUser)
        {
            _userRepo.Update(updateUser);
            await _unitOfWork.SaveAsync();
        }

        public UserResponseDTO Authentificate(UserRequestDTO model)
        {
            var user = _userRepo.FindByEmail(model.Email);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, token);
        }

        //public async Task<IEnumerable<User>> GetAllUsers()
        //{
        //    return await _userRepo.GetAllAsync();
        //}

        public List<User> GetAllUsers()
        {
            return _userRepo.FindAll().ToList();
        }

        public User GetByEmail(string email)
        {
            return _userRepo.FindByEmail(email);
        }

    }


}
