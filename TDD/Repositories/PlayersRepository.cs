using System;
using System.Collections.Generic;
using System.Linq;
using TDD.Models;

namespace TDD.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly TeamContext _context;

        public PlayersRepository(TeamContext context)
        {
            _context = context;
        }

        public List<Player> GetAll()
        {
            return _context.Players.ToList();
        }
    }
}
