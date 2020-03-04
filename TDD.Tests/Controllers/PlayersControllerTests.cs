using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD.Controllers;
using TDD.Models;
using TDD.Repositories;
using Xunit;

namespace TDD.Tests.Controllers
{
    public class PlayersControllerTests
    {
        [Fact]
        public void Players_GetAll_Returns_Ok()
        {
            var repositoryMock = new Mock<IPlayersRepository>();
            repositoryMock.Setup(x => x.GetAll()).Returns(TestPlayers());

            var playerController = new PlayersController(repositoryMock.Object);

            var action = playerController.Get() as OkObjectResult;
            var players = action.Value as List<Player>;

            Assert.NotNull(action);
            Assert.Equal(typeof(List<Player>), action.Value.GetType());
            Assert.Equal(2, players.Count);
        }

        public List<Player> TestPlayers()
        {
            var players = new List<Player>()
            {
                new Player
                {
                    Id = 1,
                    FirstName = "Player",
                    LastName = "One",
                    Position = "Attack",
                    TeamId = 1
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Player",
                    LastName = "Two",
                    Position = "Defender",
                    TeamId = 1
                }
            };

            return players;
        }
    }
}
