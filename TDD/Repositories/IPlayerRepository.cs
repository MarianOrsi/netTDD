using System;
using System.Collections.Generic;
using TDD.Models;

namespace TDD.Repositories
{
    public interface IPlayerRepository
    {
        IList<Player> GetAll();
    }
}
