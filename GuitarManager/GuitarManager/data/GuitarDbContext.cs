using GuitarManager.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarManager.data
{
    public class GuitarDbContext: DbContext
    {
        public GuitarDbContext(DbContextOptions<GuitarDbContext> options): base(options)
        {

        }

        public DbSet<Guitar> Guitars { get; set; }
    }
}
