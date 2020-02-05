using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TDD.Models;
using TDD.Repositories;
using Xunit;

namespace TDD.Tests.Repositories
{
    public class TeamRepositoryTests
    {
        [Fact]
        public void GetTeams_Test()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TeamContext>().UseInMemoryDatabase($"TeamContext_{ Guid.NewGuid() }").Options;

            using (var context = new TeamContext(options))
            {
                context.Add(new Team()
                {
                    Id = 1,
                    City = "Chicago",
                    Name = "Chicago Fire",
                    DateOfFoundation = DateTime.Now
                });

                context.Add(new Team()
                {
                    Id = 2,
                    City = "Los Angeles",
                    Name = "Los Angeles Galaxy",
                    DateOfFoundation = DateTime.Now
                });

                context.SaveChanges();

                var repository = new TeamsRepository(context);

                //Act
                var teams = repository.GetTeams().ToList();

                //Assert
                Assert.Equal(2, teams.Count);
            }
        }

        [Fact]
        public void GetTeam_Test()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TeamContext>().UseInMemoryDatabase($"TeamContext_{ Guid.NewGuid() }").Options;

            using (var context = new TeamContext(options))
            {
                context.Add(new Team()
                {
                    Id = 1,
                    City = "Chicago",
                    Name = "Chicago Fire",
                    DateOfFoundation = DateTime.Now
                });

                context.Add(new Team()
                {
                    Id = 2,
                    City = "Los Angeles",
                    Name = "Los Angeles Galaxy",
                    DateOfFoundation = DateTime.Now
                });

                context.SaveChanges();

                var repository = new TeamsRepository(context);

                //Act
                var team = repository.GetTeam(1);

                //Assert
                Assert.Equal("Chicago", team.City);
                Assert.Equal("Chicago Fire", team.Name);
            }
        }

        [Fact]
        public void RemoveTeam_Test()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TeamContext>().UseInMemoryDatabase($"TeamContext_{ Guid.NewGuid() }").Options;

            using (var context = new TeamContext(options))
            {
                context.Add(new Team()
                {
                    Id = 1,
                    City = "Chicago",
                    Name = "Chicago Fire",
                    DateOfFoundation = DateTime.Now
                });

                context.Add(new Team()
                {
                    Id = 2,
                    City = "Los Angeles",
                    Name = "Los Angeles Galaxy",
                    DateOfFoundation = DateTime.Now
                });

                context.SaveChanges();

                var repository = new TeamsRepository(context);

                //Act
                repository.RemoveTeam(1);
                var teams = repository.GetTeams().ToList();

                //Assert
                Assert.Equal(1, teams.Count);
            }
        }

        [Fact]
        public void AddTeam_Test()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TeamContext>().UseInMemoryDatabase($"TeamContext_{ Guid.NewGuid() }").Options;

            using (var context = new TeamContext(options))
            {
                context.Add(new Team()
                {
                    Id = 1,
                    City = "Chicago",
                    Name = "Chicago Fire",
                    DateOfFoundation = DateTime.Now
                });

                context.Add(new Team()
                {
                    Id = 2,
                    City = "Los Angeles",
                    Name = "Los Angeles Galaxy",
                    DateOfFoundation = DateTime.Now
                });

                context.SaveChanges();

                var repository = new TeamsRepository(context);
                var team = new Team()
                {
                    City = "Atlanta",
                    Name = "Atlanta United"
                };

                //Act
                repository.AddTeam(team);
                var teams = repository.GetTeams().ToList();

                //Assert
                Assert.Equal(3, teams.Count);
            }
        }
    }
}
