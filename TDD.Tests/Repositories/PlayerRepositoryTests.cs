using System;
using Microsoft.EntityFrameworkCore;
using TDD.Models;
using TDD.Repositories;
using TDD.Tests.Providers;
using Xunit;

namespace TDD.Tests.Repositories
{
    public class PlayerRepositoryTests
    {
        [Fact]
        public void GetAllPlayers_Ok()
        {
            var options = new DbContextOptionsBuilder<TeamContext>().UseInMemoryDatabase($"PlayerContext_{ Guid.NewGuid() }").Options;

            using (var context = new TeamContext(options))
            {
                context.AddRange(TestDataProvider.Players);
                context.SaveChanges();

                var repository = new PlayerRepository(context);
                var players = repository.GetAll();

                Assert.Equal(2, players.Count);
            }
        }
    }
}
