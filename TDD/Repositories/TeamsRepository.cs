using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TDD.Models;

namespace TDD.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly TeamContext _context;

        public TeamsRepository(TeamContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.Include(x => x.Players).ToList();
        }

        public Team GetTeam(int teamId)
        {
            return _context.Teams.Include(x => x.Players).FirstOrDefault(team => team.Id == teamId);
        }

        public Team AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();

            return team;
        }

        public Team RemoveTeam(int teamId)
        {
            var team = _context.Teams.FirstOrDefault(team => team.Id == teamId);

            if (team == null)
            {
                return null;
            }

            _context.Teams.Remove(team);
            _context.SaveChanges();

            return team;
        }
    }
}
