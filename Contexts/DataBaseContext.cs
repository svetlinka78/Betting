using Betting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.Contexts
{
    public class DataBaseContext: DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder option)
        {
            var connectionString = string.Format(@"Data Source=DESKTOP-1ACHD0U;Initial Catalog=Beeting;Integrated Security=True");
            option.UseSqlServer(connectionString).LogTo(Console.WriteLine,LogLevel.Information);
        }
        public DbSet<SportT>Sports { get; set; }
        public DbSet<EventT>Events { get; set; }

        public DbSet<MatchT>Matches { get; set; }
        public DbSet<BetT> Bets { get; set; }
        public DbSet<OddT> Odds { get; set; }

    }
}
