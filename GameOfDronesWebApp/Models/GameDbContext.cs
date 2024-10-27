using System;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GameOfDronesWebApp.Models
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
    }
}

