using Microsoft.EntityFrameworkCore;

namespace TDD.Models
{
    public partial class TeamContext : DbContext
    {
        public TeamContext()
        {
        }

        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
    }
}
