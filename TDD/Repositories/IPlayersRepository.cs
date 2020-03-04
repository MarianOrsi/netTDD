using System;
using System.Collections.Generic;
using TDD.Models;

namespace TDD.Repositories
{
    public interface IPlayersRepository
    {
        List<Player> GetAll();
    }
}
