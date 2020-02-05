using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDD.Models;
using TDD.Repositories;

namespace TDD.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _teamRepository;

        public TeamsController(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet(Name = "GetTeams")]
        public IActionResult GetTeams()
        {
            try
            {
                var teams = _teamRepository.GetTeams();

                return Ok(teams);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{teamId}", Name = "GetTeam")]
        public IActionResult GetTeam(int teamId)
        {
            try
            {
                var team = _teamRepository.GetTeam(teamId);

                if (team == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Team with Id {teamId} doesn't exists");
                }

                return Ok(team);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost(Name = "CreateTeam")]
        public IActionResult AddTeam(Team team)
        {
            try
            {
                var teamAdded = _teamRepository.AddTeam(team);

                return Created("CreateTeam", teamAdded);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{teamId}",Name = "DeleteTeam")]
        public IActionResult DeleteTeam(int teamId)
        {
            try
            {
                var teamRemoved = _teamRepository.RemoveTeam(teamId);

                if (teamRemoved == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Team with Id {teamId} doesn't exists");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
