using Microsoft.EntityFrameworkCore;
using Racunala.Models;

namespace Racunala.Data
{
    public class RacunalaContext : DbContext
    {
        public RacunalaContext (DbContextOptions<RacunalaContext> options)
            : base(options)
        {
        }

        public DbSet<Racunalo> Racunalo { get; set; }
    }
}