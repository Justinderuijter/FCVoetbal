using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCVoetbal.Data.Migrations
{
    public partial class FixedTeamMatchRelationshipPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Plaats = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matches_Team_ThuisTeamId",
                        column: x => x.ThuisTeamId,
                        principalTable: "Team",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Matches_Team_UitTeamId",
                        column: x => x.UitTeamId,
                        principalTable: "Team",
                        principalColumn: "ID");
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_GebruikerMatch_Matches_MatchID",
                table: "GebruikerMatch",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GebruikerMatch_Matches_MatchID",
                table: "GebruikerMatch");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_GebruikerMatch_MatchID",
                table: "GebruikerMatch");
        }
    }
}
