using System.Collections.Generic;
using TDD.Models;

namespace TDD.Repositories
{
    public interface ITeamsRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeam(int teamId);
        Team AddTeam(Team team);
        Team RemoveTeam(int teamId);
    }
}
