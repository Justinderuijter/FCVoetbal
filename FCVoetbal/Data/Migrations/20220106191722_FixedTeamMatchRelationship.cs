using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCVoetbal.Data.Migrations
{
    public partial class FixedTeamMatchRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plaats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuisDoelpunten = table.Column<int>(type: "int", nullable: true),
                    ThuisTeamId = table.Column<int>(type: "int", nullable: false),
                    UitDoelpunten = table.Column<int>(type: "int", nullable: true),
                    UitTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matches_Team_ThuisTeamId",
                        column: x => x.ThuisTeamId,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Team_UitTeamId",
                        column: x => x.UitTeamId,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
    }
}
