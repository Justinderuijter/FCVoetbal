using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCVoetbal.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Wachtwoord = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefoon = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThuisTeamId = table.Column<int>(nullable: false),
                    UitTeamId = table.Column<int>(nullable: false),
                    ThuisDoelpunten = table.Column<int>(nullable: true),
                    UitDoelpunten = table.Column<int>(nullable: true),
                    Plaats = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matches_Team_ThuisTeamId",
                        column: x => x.ThuisTeamId,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Team_UitTeamId",
                        column: x => x.UitTeamId,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Speler",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Rugnummer = table.Column<int>(nullable: false),
                    Doelpunten = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Speler_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaats = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Training_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerMatch",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerID = table.Column<int>(nullable: false),
                    MatchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerMatch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GebruikerMatch_Gebruiker_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruiker",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerMatch_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerMatch_GebruikerID",
                table: "GebruikerMatch",
                column: "GebruikerID");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerMatch_MatchID",
                table: "GebruikerMatch",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ThuisTeamId",
                table: "Matches",
                column: "ThuisTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_UitTeamId",
                table: "Matches",
                column: "UitTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Speler_TeamID",
                table: "Speler",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TeamID",
                table: "Training",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GebruikerMatch");

            migrationBuilder.DropTable(
                name: "Speler");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
