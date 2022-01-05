﻿// <auto-generated />
using System;
using FCVoetbal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FCVoetbal.Data.Migrations
{
    [DbContext(typeof(VoetbalContext))]
    partial class VoetbalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FCVoetbal.Models.Gebruiker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Telefoon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("FCVoetbal.Models.GebruikerMatch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerID")
                        .HasColumnType("int");

                    b.Property<int>("MatchID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GebruikerID");

                    b.HasIndex("MatchID");

                    b.ToTable("GebruikerMatch");
                });

            modelBuilder.Entity("FCVoetbal.Models.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plaats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThuisDoelpunten")
                        .HasColumnType("int");

                    b.Property<int>("ThuisTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("UitDoelpunten")
                        .HasColumnType("int");

                    b.Property<int>("UitTeamId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ThuisTeamId");

                    b.HasIndex("UitTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FCVoetbal.Models.Speler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Doelpunten")
                        .HasColumnType("int");

                    b.Property<int?>("Rugnummer")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Speler");
                });

            modelBuilder.Entity("FCVoetbal.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("FCVoetbal.Models.Training", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plaats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("FCVoetbal.Models.GebruikerMatch", b =>
                {
                    b.HasOne("FCVoetbal.Models.Gebruiker", "Gebruiker")
                        .WithMany("GebruikersMatch")
                        .HasForeignKey("GebruikerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCVoetbal.Models.Match", "Match")
                        .WithMany("GebruikerMatches")
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCVoetbal.Models.Match", b =>
                {
                    b.HasOne("FCVoetbal.Models.Team", "ThuisTeam")
                        .WithMany()
                        .HasForeignKey("ThuisTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCVoetbal.Models.Team", "UitTeam")
                        .WithMany()
                        .HasForeignKey("UitTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FCVoetbal.Models.Speler", b =>
                {
                    b.HasOne("FCVoetbal.Models.Team", "Team")
                        .WithMany("Spelers")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("FCVoetbal.Models.Training", b =>
                {
                    b.HasOne("FCVoetbal.Models.Team", "Team")
                        .WithMany("Trainingen")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
