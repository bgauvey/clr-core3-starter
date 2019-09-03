using clr_core3_starter.Models;
using Microsoft.EntityFrameworkCore;

namespace clr_core3_starter.Repository
{
    public class MesDbContext: DbContext
    {
        public MesDbContext(DbContextOptions<MesDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }

    }
}
