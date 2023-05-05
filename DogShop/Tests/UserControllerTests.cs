using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogShop.Models.DTO;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using DogShop.Services;
using DogShop.Models;
using Newtonsoft.Json;
using DogShop.Migrations;
using Newtonsoft.Json.Linq;

namespace DogShop.Tests
{
    [TestClass]
    public class UserControllerTests
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
        public async Task CreateUser_GetUserById_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_CreateUser_GetUser_ReturnsOk_FirstName",
                LastName = "Test_CreateUser_GetUser_ReturnsOk_LastName",
                Email = "Test_CreateUser_GetUser_ReturnsOk_Email",
                Password = "Test_CreateUser_GetUser_ReturnsOk_Password"
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync(); 
            Guid userId = Guid.Parse(body.Trim('"'));

            var responseGet = await _httpClient.GetAsync($"/api/User/GetUserById/{userId}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<User>(responseGetBody);


            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(userRequestDTO.FirstName, userResponse.FirstName);
            Assert.AreEqual(userRequestDTO.LastName, userResponse.LastName);
            Assert.AreEqual(userRequestDTO.Email, userResponse.Email);
        }

        [TestMethod]
        public async Task CreateUser_ReturnsBadRequest()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO();

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);

            //Assert
            Assert.AreEqual("Bad Request", responsePost.ReasonPhrase);
        }

        [TestMethod]
        public async Task PutUser_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_PutUser_ReturnsOk_FirstName",
                LastName = "Test_PutUser_ReturnsOk_LastName",
                Email = "Test_PutUser_ReturnsOk_Email",
                Password = "Test_PutUser_ReturnsOk_Password"
            };

            var userRequestDTOUpdate = new UserRequestDTO
            {
                FirstName = "Test_PutUser_ReturnsOk_FirstName_Update",
                LastName = "Test_PutUser_ReturnsOk_LastName_Update",
                Email = "Test_PutUser_ReturnsOk_Email_Update",
                Password = "Test_PutUser_ReturnsOk_Password_Update"
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync();
            Guid userId = Guid.Parse(body.Trim('"'));

            var responsePut = await _httpClient.PutAsJsonAsync($"/api/User/UpdateUser/{userId}", userRequestDTOUpdate);

            var responseGet = await _httpClient.GetAsync($"/api/User/GetUserById/{userId}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<User>(responseGetBody);


            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responsePut.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(userRequestDTOUpdate.FirstName, userResponse.FirstName);
            Assert.AreEqual(userRequestDTOUpdate.LastName, userResponse.LastName);
            Assert.AreEqual(userRequestDTOUpdate.Email, userResponse.Email);
        }

        [TestMethod]
        public async Task PutUser_ReturnsBadRequest()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_PutUser_ReturnsOk_FirstName",
                LastName = "Test_PutUser_ReturnsOk_LastName",
                Email = "Test_PutUser_ReturnsOk_Email",
                Password = "Test_PutUser_ReturnsOk_Password"
            };

            var userRequestDTOUpdate = new UserRequestDTO
            {
                FirstName = "Test_PutUser_ReturnsOk_FirstName_Update",
                LastName = "Test_PutUser_ReturnsOk_LastName_Update",
                Email = "Test_PutUser_ReturnsOk_Email_Update",
                //Password = "Test_PutUser_ReturnsOk_Password_Update"
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync();
            Guid userId = Guid.Parse(body.Trim('"'));

            var responsePut = await _httpClient.PutAsJsonAsync($"/api/User/UpdateUser/{userId}", userRequestDTOUpdate);

            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("Bad Request", responsePut.ReasonPhrase);
        }

        [TestMethod]
        public async Task DeleteUser_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_CreateUser_GetUser_ReturnsOk_FirstName",
                LastName = "Test_CreateUser_GetUser_ReturnsOk_LastName",
                Email = "Test_CreateUser_GetUser_ReturnsOk_Email",
                Password = "Test_CreateUser_GetUser_ReturnsOk_Password"
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);
            var body = await responsePost.Content.ReadAsStringAsync();
            Guid userId = Guid.Parse(body.Trim('"'));

            var responseDelete = await _httpClient.DeleteAsync($"/api/User/DeleteUser/{userId}");

            var responseGet = await _httpClient.GetAsync($"/api/User/GetUserById/{userId}");


            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responseDelete.ReasonPhrase);
            Assert.AreEqual("Not Found", responseGet.ReasonPhrase);
        }

        [TestMethod]
        public async Task GetUserByEmail_ReturnsOk()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_GetUserByEmail_ReturnsOk_FirstName",
                LastName = "Test_GetUserByEmail_ReturnsOk_LastName",
                Email = "Test_GetUserByEmail_ReturnsOk_Email",
                Password = "Test_GetUserByEmail_ReturnsOk_Password"
            };

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);

            var responseGet = await _httpClient.GetAsync($"/api/User/GetUserByEmail/{userRequestDTO.Email}");
            var responseGetBody = await responseGet.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<User>(responseGetBody);

            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("OK", responseGet.ReasonPhrase);
            Assert.AreEqual(userRequestDTO.FirstName, userResponse.FirstName);
            Assert.AreEqual(userRequestDTO.LastName, userResponse.LastName);
            Assert.AreEqual(userRequestDTO.Email, userResponse.Email);
        }

        [TestMethod]
        public async Task GetUserByEmail_ReturnsNotFound()
        {
            // Arrange
            var userRequestDTO = new UserRequestDTO
            {
                FirstName = "Test_GetUserByEmail_ReturnsOk_FirstName",
                LastName = "Test_GetUserByEmail_ReturnsOk_LastName",
                Email = "Test_GetUserByEmail_ReturnsOk_Email",
                Password = "Test_GetUserByEmail_ReturnsOk_Password"
            };

            String NonExistentEmail = "NonExistentEmail";

            // Act
            var responsePost = await _httpClient.PostAsJsonAsync("/api/User/CreateUser", userRequestDTO);

            var responseGet = await _httpClient.GetAsync($"/api/User/GetUserByEmail/{NonExistentEmail}");

            Console.WriteLine(responseGet.ReasonPhrase);

            //Assert
            Assert.AreEqual("OK", responsePost.ReasonPhrase);
            Assert.AreEqual("Not Found", responseGet.ReasonPhrase);
        }
    }
}
