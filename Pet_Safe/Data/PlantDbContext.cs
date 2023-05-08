using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Safe.Models;

namespace Pet_Safe.Data
{
    public class PlantDbContext : IdentityDbContext
    {
        public PlantDbContext(DbContextOptions<PlantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
    }
}