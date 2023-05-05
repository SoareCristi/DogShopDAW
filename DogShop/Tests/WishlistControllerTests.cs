using DogShop.Models.DTO;
using DogShop.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DogShop.Tests
{
    [TestClass]
    public class WishlistControllerTests
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
        public async Task CreateWishlist_GetWishlist_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_CreateWishlist_GetWishlist_ReturnsOk_FirstName",
                LastName = "Test_CreateWishlist_GetWishlist_ReturnsOk_LastName",
                Email = "Test_CreateWishlist_GetWishlist_ReturnsOk_Email",
                Password = "Test_CreateWishlist_GetWishlist_ReturnsOk_Password"
            };

            // Act
            var responseUserPost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var bodyUser = await responseUserPost.Content.ReadAsStringAsync();
            Guid userId = Guid.Parse(bodyUser.Trim('"'));

            var wishlistRequestDTO = new WishlistRequestDTO
            {
                UserId = userId
            };

            var responseWishlistPost = await _httpClient.PostAsJsonAsync("/api/Wishlist/CreateWishlist", wishlistRequestDTO);
            var bodyWishlist = await responseWishlistPost.Content.ReadAsStringAsync();
            Guid IdWishlist = Guid.Parse(bodyWishlist.Trim('"'));

            var responseGet = await _httpClient.GetAsync($"/api/Wishlist/GetWishlistById/{IdWishlist}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var wishlistResponse = JsonConvert.DeserializeObject<Wishlist>(responseGetBody);


            //Assert
            Assert.AreEqual("OK", responseUserPost.ReasonPhrase);
            Assert.AreEqual("OK", responseWishlistPost.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(wishlistRequestDTO.UserId, wishlistResponse.UserId);
        }

        [TestMethod]
        public async Task PutWishlist_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_PutWishlist_ReturnsOk_FirstName",
                LastName = "Test_PutWishlist_ReturnsOk_LastName",
                Email = "Test_PutWishlist_ReturnsOk_Email",
                Password = "Test_PutWishlist_ReturnsOk_Password"
            };

            var userRequestDTOUpdate = new UserRequestDTO
            {
                FirstName = "Test_PutUser_ReturnsOk_FirstName_Update",
                LastName = "Test_PutUser_ReturnsOk_LastName_Update",
                Email = "Test_PutUser_ReturnsOk_Email_Update",
                Password = "Test_PutUser_ReturnsOk_Password_Update"
            };

            // Act
            var responseUserPost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var bodyUser = await responseUserPost.Content.ReadAsStringAsync();
            Guid userId = Guid.Parse(bodyUser.Trim('"'));

            var wishlistRequestDTO = new WishlistRequestDTO
            {
                UserId = userId
            };

            var responseWishlistPost = await _httpClient.PostAsJsonAsync("/api/Wishlist/CreateWishlist", wishlistRequestDTO);
            var bodyWishlist = await responseWishlistPost.Content.ReadAsStringAsync();
            Guid IdWishlist = Guid.Parse(bodyWishlist.Trim('"'));

            //Making a new user to update the wishlist
            var responseUserPostUpdate = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTOUpdate);
            var bodyUserUpdate = await responseUserPostUpdate.Content.ReadAsStringAsync();
            Guid userIdUpdate = Guid.Parse(bodyUserUpdate.Trim('"'));

            var wishlistRequestDTOUpdate = new WishlistRequestDTO
            {
                UserId = userIdUpdate
            };

            var responseWishlistPut = await _httpClient.PutAsJsonAsync($"/api/Wishlist/UpdateWishlist/{IdWishlist}", wishlistRequestDTOUpdate);

            var responseGet = await _httpClient.GetAsync($"/api/Wishlist/GetWishlistById/{IdWishlist}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var wishlistResponse = JsonConvert.DeserializeObject<Wishlist>(responseGetBody);


            //Assert
            Assert.AreEqual("OK", responseUserPost.ReasonPhrase);
            Assert.AreEqual("OK", responseWishlistPost.ReasonPhrase);
            Assert.AreEqual("OK", responseUserPostUpdate.ReasonPhrase);
            Assert.AreEqual("OK", responseWishlistPut.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(wishlistRequestDTOUpdate.UserId, wishlistResponse.UserId);
        }

        [TestMethod]
        public async Task DeleteWishlist_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_DeleteWishlist_ReturnsOk_FirstName",
                LastName = "Test_DeleteWishlist_ReturnsOk_LastName",
                Email = "Test_DeleteWishlist_ReturnsOk_Email",
                Password = "Test_DeleteWishlist_ReturnsOk_Password"
            };

            // Act
            var responseUserPost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var bodyUser = await responseUserPost.Content.ReadAsStringAsync();
            Guid userId = Guid.Parse(bodyUser.Trim('"'));

            var wishlistRequestDTO = new WishlistRequestDTO
            {
                UserId = userId
            };

            var responseWishlistPost = await _httpClient.PostAsJsonAsync("/api/Wishlist/CreateWishlist", wishlistRequestDTO);
            var bodyWishlist = await responseWishlistPost.Content.ReadAsStringAsync();
            Guid IdWishlist = Guid.Parse(bodyWishlist.Trim('"'));


            var responseDelete = await _httpClient.DeleteAsync($"/api/Wishlist/DeleteWishlist/{IdWishlist}");

            var responseGet = await _httpClient.GetAsync($"/api/Wishlist/GetUserById/{IdWishlist}");


            //Assert
            Assert.AreEqual("OK", responseUserPost.ReasonPhrase);
            Assert.AreEqual("OK", responseWishlistPost.ReasonPhrase);
            Assert.AreEqual("OK", responseDelete.ReasonPhrase);
            Assert.AreEqual("Not Found", responseGet.ReasonPhrase);
        }
    }
}
