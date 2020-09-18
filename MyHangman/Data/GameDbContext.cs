using Microsoft.AspNet.Identity.EntityFramework;
using MyHangman.Models;
using System.Data.Entity;

namespace MyHangman.Data
{
    public class GameDbContext : IdentityDbContext<Player>
    {
        public GameDbContext() : base("LiveWebConnection")
        {
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Hint> Hints { get; set; }
        public DbSet<CompleteLevel> CompleteLevels { get; set; }
        public DbSet<OpenHint> OpenHints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        public static GameDbContext Create()
        {
            return new GameDbContext();
        }
    }
}