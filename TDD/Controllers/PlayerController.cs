using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDD.Models;
using TDD.Repositories;

namespace TDD.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("GetAllPlayers")]
        public IActionResult GetAllPlayers()
        {
            var players = _playerRepository.GetAll();
            return Ok(players);
        }
    }
}
