namespace DogShop.Helper
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Models.User user);
        public Guid ValidateJwtToken(string token);
    }
}
