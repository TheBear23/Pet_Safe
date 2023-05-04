using Pet_Safe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Pet_Safe.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Plants> Plant { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<User> users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Plant>()
                .HasMany(p => p.)
                .WithMany(b => b.events);
            

            modelBuilder.Entity<Event>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Events)
                .UsingEntity(j => j.ToTable("EventTags"));
            */
            base.OnModelCreating(modelBuilder);
        }

    }
}