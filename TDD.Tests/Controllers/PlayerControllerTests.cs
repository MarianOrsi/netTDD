using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD.Controllers;
using TDD.Models;
using TDD.Repositories;
using TDD.Tests.Providers;
using Xunit;

namespace TDD.Tests.Controllers
{
    public class PlayerControllerTests
    {
        [Fact]
        public void GetAllPlayers_Ok()
        {
            var mockPlayerRepository = new Mock<IPlayerRepository>();
            mockPlayerRepository.Setup(x => x.GetAll()).Returns(TestDataProvider.Players);

            var controller = new PlayerController(mockPlayerRepository.Object);

            var result = controller.GetAllPlayers() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
    }
}
