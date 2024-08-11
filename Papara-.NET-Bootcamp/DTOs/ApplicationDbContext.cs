using System.Collections.Generic;

namespace Papara_.NET_Bootcamp.DTOs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }

    }
}
