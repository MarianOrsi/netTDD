using System;
using System.Collections.Generic;
using TDD.Models;

namespace TDD.Tests.Providers
{
    public static class TestDataProvider
    {
        public static IList<Team> Teams = new List<Team>
        {
            new Team
            {
                Id = 1,
                Name = "Dream Team",
                City = "New York",
                DateOfFoundation = DateTime.Now
            },
            new Team
            {
                Id = 2,
                Name = "FT1",
                City = "Chicago",
                DateOfFoundation = DateTime.Now
            },
            new Team
            {
                Id = 3,
                Name = "FT2",
                City = "Chicago",
                DateOfFoundation = DateTime.Now
            },
            new Team
            {
                Id = 4,
                Name = "CSM",
                City = "Chicago",
                DateOfFoundation = DateTime.Now
            }
        };
    }
}
