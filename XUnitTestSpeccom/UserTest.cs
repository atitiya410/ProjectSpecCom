using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Moq;
using SpeccomDB.Models;
using SpeccomInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebapiSpeccom.Controllers;
using Xunit;

namespace XUnitTestSpeccom
{
    public class UserTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public void TestGetUserById()
        {
            var mockRepo = new Mock<IUser>();
            mockRepo.Setup(repo => repo.GetUserByID(1)).Returns(Startup.gettestsession(1));
            
            var controller = new UsersController(mockRepo.Object);



            string expectedName = "user 1";
            var result = controller.GetUser(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<User>(okResult.Value);

            Assert.Equal(expectedName, user.UserName);
        }
    }
}
