using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TDD.Models;
using TDD.Repositories;
using Xunit;

namespace TDD.Tests.Repositories
{
    public class PlayersRepositoryTests
    {
        [Fact]
        public void GetAll_Returns_Players_Ok()
        {
            var options = new DbContextOptionsBuilder<TeamContext>().UseInMemoryDatabase($"Context_{ Guid.NewGuid() }").Options;

            using (var context = new TeamContext(options))
            {
                context.Teams.Add(new Team
                {
                    City = "BA",
                    Id = 1,
                    Name = "KIN + CARTA",
                    DateOfFoundation = DateTime.Now,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Id = 1,
                            FirstName = "Test",
                            LastName = "Test",
                            Position = "Attack"
                        }
                    }
                });
                context.SaveChanges();

                var playersRepository = new PlayersRepository(context);

                var players = playersRepository.GetAll();

                Assert.IsType<List<Player>>(players);
                Assert.Equal(1, players.Count);
            }   
        }
    }
}
