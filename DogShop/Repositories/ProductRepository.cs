using DogShop.Data;
using DogShop.Models;

namespace DogShop.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }
    }
    
}
