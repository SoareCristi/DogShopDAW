using DogShop.Repositories;
using DogShop.Models;

namespace DogShop.Services
{
    public class ProductService: IProductService
    {
        public IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task Create(Product product)
        {
            await _productRepo.CreateAsync(product);
            await _productRepo.SaveAsync();
        }

        public async Task Delete(Product product)
        {
            _productRepo.Delete(product);
            await _productRepo.SaveAsync();
        }

        public Product GetById(Guid id)
        {
            return _productRepo.FindById(id);
        }

        public bool Save()
        {
            return _productRepo.Save();
        }

        public async Task Update(Product updateProduct)
        {
            _productRepo.Update(updateProduct);
            await _productRepo.SaveAsync();
        }
    }
}
