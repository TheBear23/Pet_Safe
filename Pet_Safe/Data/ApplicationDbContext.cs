using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pet_Safe.Models;

namespace Pet_Safe.Data
{        
    
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plants> Plants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=petsafe;password=petsafe;database=pet_safe";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

            }
        }