using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballContext:DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {

        }
        public DbSet<Bet> bets => Set<Bet>();
        public DbSet<Color> colors => Set<Color>();
        public DbSet<Country> countries=>Set<Country>();
        public DbSet<Game> games => Set<Game>();
        public DbSet<Player> players => Set<Player>();
        public DbSet<PlayerStatistics> playerStatistics => Set<PlayerStatistics>();
        public DbSet<Position> positions => Set<Position>();
        public DbSet<Teams> teams => Set<Teams>();
        public DbSet<User> users => Set<User>();
        public DbSet<Town> towns => Set<Town>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId).HasName("PK__Teams");
                entity.Property(e => e.Name);
                entity.Property(e => e.LogoUrl);
                entity.Property(e => e.Initials);
                entity.Property(e => e.Budget);
                entity.HasOne(d => d.PrimaryColors).WithMany(p => p.TeamsPrimary)
                    .HasForeignKey(d => d.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teams_Colors1");
                entity.HasOne(d => d.SecondaryColors).WithMany(p => p.TeamsSecondary)
                    .HasForeignKey(d => d.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teams_Colors2");
                entity.HasOne(d => d.Town).WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teams_Towns");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId).HasName("PK__Colors");

                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId).HasName("PK__Towns");

                entity.Property(e => e.Name);
                entity.HasOne(d => d.Country).WithMany(p => p.Towns)
                   .HasForeignKey(d => d.CountryId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Towns_Countries");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId).HasName("PK__Countries");

                entity.Property(e => e.CountryName);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId).HasName("PK__Players");

                entity.Property(e => e.Name);
                entity.Property(e => e.SquadNumber);
                entity.Property(e => e.IsInjured);
                entity.HasOne(d => d.Position).WithMany(p => p.Players)
                   .HasForeignKey(d => d.PositionId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Players_Positions");
                entity.HasOne(d => d.Teams).WithMany(p => p.Players)
                  .HasForeignKey(d => d.TeamId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Players_Teams");
            });
            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId).HasName("PK__Positions");

                entity.Property(e => e.PositionName);
            });
            modelBuilder.Entity<PlayerStatistics>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GameId }).HasName("PK__PlayerStatistics");
                entity.HasOne(d => d.Player).WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerStatistics_Players");
                entity.HasOne(d => d.Game).WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerStatistics_Games");
                entity.Property(e => e.ScoredGoals);
                entity.Property(e => e.Assists);
                entity.Property(e => e.MinutesPlayed);
            });
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId).HasName("PK__Games");

                entity.HasOne(d => d.HomeTeam).WithMany(p => p.HomeGames)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_Teams1");
                entity.HasOne(d => d.AwayTeam).WithMany(p => p.AwayGames)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_Teams2");
                entity.Property(e => e.HomeTeamGoals);
                entity.Property(e => e.AwayTeamGoals);
                entity.Property(e => e.DateTime);
                entity.Property(e => e.HomeTeamBetRate);
                entity.Property(e => e.AwayTeamBetRate);
                entity.Property(e => e.DrawBetRate);
                entity.Property(e => e.Result);
            });
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId).HasName("PK__Bets");

                entity.Property(e => e.BetAmount);
                entity.Property(e => e.Prediction);
                entity.Property(e => e.DateTime);
                entity.HasOne(d => d.User).WithMany(p => p.Bets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bets_Users");
                entity.HasOne(d => d.Game).WithMany(p => p.Bets)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bets_Games");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users");

                entity.Property(e => e.UserName);
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.Name);
                entity.Property(e => e.Balance);
            });
        }
    }
}
