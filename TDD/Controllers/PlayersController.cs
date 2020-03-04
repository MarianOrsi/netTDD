using System;
using Microsoft.AspNetCore.Mvc;
using TDD.Repositories;

namespace TDD.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        [HttpGet(Name = "GetAllPlayers")]
        public IActionResult Get()
        {
            var players = _playersRepository.GetAll();

            return Ok(players);
        }
    }
}
