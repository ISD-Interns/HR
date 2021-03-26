using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class HaloRunsDbContext : DbContext
    {
        public HaloRunsDbContext()
            : base() { }

        public HaloRunsDbContext(DbContextOptions<HaloRunsDbContext> options)
            : base(options) { }

        public DbSet<game> Games { get; set; }
        public DbSet<map> Maps { get; set; }
        public DbSet<run> Runs { get; set; }

        public DbSet<user> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<map>().ToTable("HR_maps");
            modelBuilder.Entity<game>().ToTable("HR_games");
            modelBuilder.Entity<run>().ToTable("HR_runs");
            modelBuilder.Entity<user>().ToTable("HR_users");
            modelBuilder.Entity<edition>().ToTable("HR_editions");

            modelBuilder
                .Entity<game>()
                .HasMany<map>(g => g.Maps)
                .WithOne(m => m.Game)
                .HasForeignKey(m => m.GameId) //must return an int 
                .HasPrincipalKey(g => g.id);

            modelBuilder
                .Entity<run>()
                .HasOne<map>(r => r.Map)
                .WithMany(m => m.Runs)
                .HasForeignKey(r => r.MapId)
                .HasPrincipalKey(m => m.id);

            modelBuilder
                .Entity<edition>()
                .HasOne<game>(e => e.Game)
                .WithMany(g => g.Editions)
                .HasForeignKey(e => e.GameId)
                .HasPrincipalKey(g => g.id);

            modelBuilder
                .Entity<user>()
                .HasMany<run>(u => u.Runs)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder
                .Entity<run>()
                .HasOne<edition>(r => r.Edition)
                .WithMany()
                .HasForeignKey(r => r.EditionId)
                .HasPrincipalKey(e => e.Id);
            
        }
    }
}
