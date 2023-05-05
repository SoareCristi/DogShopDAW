using DogShop.Models.DTO;
using DogShop.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DogShop.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var appSettingsPath = Path.Combine(projectDir, "appsettings.json");


            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseEnvironment("Testing");
                    builder.UseContentRoot(projectDir);
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                        config.AddJsonFile(appSettingsPath);
                    });
                });

            _httpClient = _factory.CreateClient();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _httpClient?.Dispose();
            _factory?.Dispose();
        }

        [TestMethod]
        public async Task CreateProduct_GetProductById_ReturnsOk()
        {
            // Arrange
            var productRequestDTO = new ProductRequestDTO
            {
                Price = 1,
                Name = "Test_CreateProduct_GetProductById_ReturnsOk_Name",
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/Product/CreateProduct", productRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync();
            Guid productId = Guid.Parse(body.Trim('"'));

            var responseGet = await _httpClient.GetAsync($"/api/Product/GetProductById/{productId}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<Product>(responseGetBody);


            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(productRequestDTO.Price, userResponse.Price);
            Assert.AreEqual(productRequestDTO.Name, userResponse.Name);
        }

        [TestMethod]
        public async Task CreateProduct_ReturnsBadRequest()
        {
            // Arrange
            var productRequestDTO = new ProductRequestDTO();

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/Product/CreateProduct", productRequestDTO);

            //Assert
            Assert.AreEqual("Bad Request", responsePost.ReasonPhrase);
        }

        [TestMethod]
        public async Task PutProduct_ReturnsOk()
        {
            // Arrange
            var productRequestDTO = new ProductRequestDTO
            {
                Price = 1,
                Name = "Test_PutProduct_ReturnsOk_Name",
            };

            var productRequestDTOUpdate = new ProductRequestDTO
            {
                Price = 2,
                Name = "Test_PutProduct_ReturnsOk_Name_Update",
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/Product/CreateProduct", productRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync();
            Guid productId = Guid.Parse(body.Trim('"'));

            var responsePut = await _httpClient.PutAsJsonAsync($"/api/Product/UpdateProduct/{productId}", productRequestDTOUpdate);

            var responseGet = await _httpClient.GetAsync($"/api/Product/GetProductById/{productId}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<Product>(responseGetBody);


            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responsePut.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(productRequestDTOUpdate.Price, userResponse.Price);
            Assert.AreEqual(productRequestDTOUpdate.Name, userResponse.Name);
        }

        [TestMethod]
        public async Task DeleteProduct_ReturnsOk()
        {
            // Arrange
            var productRequestDTO = new ProductRequestDTO
            {
                Price = 1,
                Name = "Test_DeleteProduct_ReturnsOk_Name",
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/Product/CreateProduct", productRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync();
            Guid productId = Guid.Parse(body.Trim('"'));

            var responseDelete = await _httpClient.DeleteAsync($"/api/Product/DeleteProduct/{productId}");

            var responseGet = await _httpClient.GetAsync($"/api/Product/GetProductById/{productId}");


            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responseDelete.ReasonPhrase);
            Assert.AreEqual("Not Found", responseGet.ReasonPhrase);
        }
    }
}
