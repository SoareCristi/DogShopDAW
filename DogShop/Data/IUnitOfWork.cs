namespace DogShop.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveAsync();
    }
}
