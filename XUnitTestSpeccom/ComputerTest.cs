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
    public class ComputerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ComputerTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public void TestGetComputerById()
        {
            var mockRepo = new Mock<IComputer>();
            mockRepo.Setup(repo => repo.GetComputerByID("AAA")).Returns(Startup.gettestsession("AAA"));
            //var mockRepo = new Mock<IUser>();
            //mockRepo.Setup(repo => repo.GetUserByID(1)).Returns(Startup.gettestsession(1));
            var controller = new ComputersController(mockRepo.Object);



            string expectedName = "computer AAA";
            var result = controller.GetComputer("AAA");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var com = Assert.IsType<Computer>(okResult.Value);

            Assert.Equal(expectedName, com.Cpuname);
        }
    }
}
