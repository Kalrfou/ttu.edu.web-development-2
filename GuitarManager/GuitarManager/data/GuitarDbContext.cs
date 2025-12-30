using GuitarManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace GuitarManager.data
{
    public class GuitarDbContext: IdentityDbContext<ApplicationUser>
    {
        public GuitarDbContext(DbContextOptions<GuitarDbContext> options): base(options)
        {

        }

        public DbSet<Guitar> Guitars { get; set; }
    }
}
