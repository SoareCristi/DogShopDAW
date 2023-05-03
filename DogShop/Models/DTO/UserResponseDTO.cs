namespace DogShop.Models
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Guid? WishlistId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            //WishlistId = user.WishlistId;
            Token = token;
        }
    }
}
