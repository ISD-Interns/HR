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

        public DbSet<Game> Games { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Run> Runs { get; set; }

        public DbSet<Edition> Editions {get; set;}

        public DbSet<User> Users { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Map>().ToTable("HR_maps");
            modelBuilder.Entity<Game>().ToTable("HR_games");
            modelBuilder.Entity<Run>().ToTable("HR_runs");
            modelBuilder.Entity<User>().ToTable("HR_users");
            modelBuilder.Entity<Edition>().ToTable("HR_editions");
            modelBuilder.Entity<Difficulty>().ToTable("HR_difficulty");
            //modelBuilder.Entity<user_game>().ToTable("HR_user_game");

            modelBuilder
                .Entity<Game>(gameEntity =>
                {
                    gameEntity.HasMany<Map>(g => g.Maps)
                    .WithOne(m => m.Game)
                    .HasForeignKey(m => m.GameId) //must return an int 
                    .HasPrincipalKey(g => g.id);


                    /*
                    gameEntity.HasMany<user_game>()
						.WithOne(m => m.Game)
						.HasForeignKey(ug => ug.GameID);
                    */
                });

             modelBuilder   
                .Entity<User>(userEntity =>
                {
                    userEntity.HasMany<Run>(u => u.Runs)
                    .WithOne(r => r.User)
                    .HasForeignKey(r => r.UserId)
                    .HasPrincipalKey(u => u.Id);

                    userEntity.HasMany(u => u.Games)
                        .WithMany(g => g.Users)
                        .UsingEntity<user_game>(
							pivot_table => pivot_table
								.HasOne(pt => pt.Game)
                                .WithMany(u => u.UserGames)
                                .HasForeignKey(pt => pt.GameId),
							pivot_table => pivot_table
                                .HasOne(pt => pt.User)
								.WithMany(u => u.UserGames)
								.HasForeignKey(pt => pt.UserId),
                            //null
							pivot_table => pivot_table.ToTable("HR_user_game")
                        );

                    /*
                    userEntity.HasMany<user_game>()
						.WithOne(u => u.User)
						.HasForeignKey(uu => uu.UserID);
                    */
                });

            modelBuilder
                .Entity<Run>()
                .HasOne<Map>(r => r.Map)
                .WithMany(m => m.Runs)
                .HasForeignKey(r => r.MapId)
                .HasPrincipalKey(m => m.id);

            modelBuilder
                .Entity<Edition>()
                .HasOne<Game>(e => e.Game)
                .WithMany(g => g.Editions)
                .HasForeignKey(e => e.GameId)
                .HasPrincipalKey(g => g.id);

            modelBuilder
                .Entity<User>()
                .HasMany<Run>(u => u.Runs)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder
                .Entity<Run>()
                .HasOne<Edition>(r => r.Edition)
                .WithMany()
                .HasForeignKey(r => r.EditionId)
                .HasPrincipalKey(e => e.Id);

            /*
            modelBuilder
                .Entity<user>()
                .HasOne<game>(u => u.Game)
                .WithMany()
                .HasForeignKey(u => u.FavoriteGameID)
                .HasPrincipalKey(g => g.id);
            */
            modelBuilder
                .Entity<Run>()
                .HasOne<Difficulty>(r => r.Difficulty)
                .WithMany()
                .HasForeignKey(r => r.DifficultyId)
                .HasPrincipalKey(d => d.Id);
        }
    }
}
