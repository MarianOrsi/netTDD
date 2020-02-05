using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD.Controllers;
using TDD.Repositories;
using TDD.Tests.Providers;
using Xunit;

namespace TDD.Tests.Controllers
{
    public class TeamControllerTests
    {
        [Fact]
        public void GetTeams_Ok()
        {
            var repositoryMock = new Mock<ITeamsRepository>();
            repositoryMock.Setup(x => x.GetTeams()).Returns(TestDataProvider.Teams);

            var controller = new TeamsController(repositoryMock.Object);

            var result = controller.GetTeams() as ObjectResult;

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void GetTeams_Error500()
        {
            var repositoryMock = new Mock<ITeamsRepository>();
            repositoryMock.Setup(x => x.GetTeams()).Throws<Exception>();

            var controller = new TeamsController(repositoryMock.Object);

            var result = controller.GetTeams() as ObjectResult;

            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Fact]
        public void GetTeam_Ok()
        {
            var repositoryMock = new Mock<ITeamsRepository>();
            repositoryMock.Setup(x => x.GetTeam(1)).Returns(TestDataProvider.Teams.FirstOrDefault(team => team.Id == 1));

            var controller = new TeamsController(repositoryMock.Object);

            var result = controller.GetTeam(1) as ObjectResult;

            Assert.Equal(typeof(OkObjectResult), result.GetType());
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void GetTeam_NotFound()
        {
            var repositoryMock = new Mock<ITeamsRepository>();
            repositoryMock.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(TestDataProvider.Teams.FirstOrDefault(team => team.Id == 1000));

            var controller = new TeamsController(repositoryMock.Object);

            var result = controller.GetTeam(1000) as ObjectResult;

            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void DeleteTeam_Ok()
        {
            var repositoryMock = new Mock<ITeamsRepository>();
            repositoryMock.Setup(x => x.RemoveTeam(It.IsAny<int>())).Returns(TestDataProvider.Teams.FirstOrDefault());

            var controller = new TeamsController(repositoryMock.Object);

            var result = controller.DeleteTeam(1) as NoContentResult;

            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
