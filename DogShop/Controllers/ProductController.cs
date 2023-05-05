using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogShop.Models;
using DogShop.Models.DTO;
using DogShop.Services;

namespace DogShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController( IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductRequestDTO newProduct)
        {
            var product = new Product
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                DateCreated = DateTime.Now,
            };
            await _productService.Create(product);
            Console.WriteLine(product.Id);
            return Ok(product.Id);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductRequestDTO updateProduct)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            product.DateModified = DateTime.Now;
            await _productService.Update(product);
            return Ok();
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            await _productService.Delete(product);
            _productService.Save();
            return Ok();
        }

    }
}
