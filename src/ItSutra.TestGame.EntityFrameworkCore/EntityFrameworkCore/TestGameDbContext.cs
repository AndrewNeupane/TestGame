using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ItSutra.TestGame.Authorization.Roles;
using ItSutra.TestGame.Authorization.Users;
using ItSutra.TestGame.MultiTenancy;
using ItSutra.TestGame.Model;

namespace ItSutra.TestGame.EntityFrameworkCore
{
    public class TestGameDbContext : AbpZeroDbContext<Tenant, Role, User, TestGameDbContext>
    {
        public DbSet<Player> Players {get; set;}
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchMove> matchMoves { get; set; }
        public TestGameDbContext(DbContextOptions<TestGameDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(x => x.FirstPlayer)
                .WithMany()
                .HasForeignKey(m => m.FirstPlayerId);
            modelBuilder.Entity<Match>()
              .HasOne(x => x.SecondPlayer)
              .WithMany()
              .HasForeignKey(m => m.SecondPlayerId);
            modelBuilder.Entity<Match>()
              .HasOne(x => x.WinningPlayer)
              .WithMany()
              .HasForeignKey(m => m.WinningPlayerId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
