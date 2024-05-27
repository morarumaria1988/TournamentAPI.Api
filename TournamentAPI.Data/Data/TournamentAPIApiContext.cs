using Microsoft.EntityFrameworkCore;

namespace TournamentAPI.Data.Data
    {
    public class TournamentAPIApiContext : DbContext
        {
        public TournamentAPIApiContext(DbContextOptions<TournamentAPIApiContext> options)
            : base(options)
            {
            }

        public DbSet<TournamentAPI.Core.Entities.Tournament> Tournaments { get; set; } = default!;
        public DbSet<TournamentAPI.Core.Entities.Game> Games { get; set; } = default!;
        }
    }
