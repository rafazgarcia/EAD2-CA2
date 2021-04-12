using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADcaAPI
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Game { get; set; }
        public GameContext()
        {

        }
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }
    }
}
