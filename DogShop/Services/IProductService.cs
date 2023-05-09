using DogShop.Models;

namespace DogShop.Services
{
    public interface IProductService
    {
        Task Create(Product product);
        Task Delete(Product product);
        Product GetById(Guid id);
        Task Save();
        Task Update(Product updateProduct);
    }
}
