using DogShop.Repositories;
using DogShop.Models;
using DogShop.Data;

namespace DogShop.Services
{
    public class ProductService: IProductService
    {
        public IProductRepository _productRepo;
        public IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepo, IUnitOfWork unitOfWork)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
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

        public async Task Save()
        {
            await _unitOfWork.SaveAsync();//_productRepo.Save();
        }

        public async Task Update(Product updateProduct)
        {
            _productRepo.Update(updateProduct);
            await _unitOfWork.SaveAsync();
        }
    }
}
