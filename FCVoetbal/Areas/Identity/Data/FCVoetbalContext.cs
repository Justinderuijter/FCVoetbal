using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCVoetbal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FCVoetbal.Data
{
    public class VoetbalContext : IdentityDbContext
    {
        public VoetbalContext(DbContextOptions<VoetbalContext> options) : base(options)
        {

        }

        //public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<GebruikerMatch> GebruikersMatches { get; set; }
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Training> Trainingen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>().HasKey(p => p.ID);
            modelBuilder.Entity<Match>()
            .HasOne(m => m.ThuisTeam)
            .WithMany(m => m.ThuisMatchen)
            .HasForeignKey(m => m.ThuisTeamId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.UitTeam)
                .WithMany(m => m.UitMatchen)
                .HasForeignKey(m => m.UitTeamId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<GebruikerMatch>().ToTable("GebruikerMatch");
            modelBuilder.Entity<Speler>().ToTable("Speler");

            modelBuilder.Entity<Team>().HasKey(t => t.ID);
            modelBuilder.Entity<Team>().ToTable("Team");

            modelBuilder.Entity<Training>().ToTable("Training");
        }
    }
}
