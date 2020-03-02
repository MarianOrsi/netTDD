using System;
using System.Collections.Generic;
using TDD.Models;

namespace TDD.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly TeamContext _context;

        public PlayerRepository(TeamContext context)
        {
            _context = context;
        }

        public IList<Player> GetAll()
        {
            return new List<Player>();
        }
    }
}
