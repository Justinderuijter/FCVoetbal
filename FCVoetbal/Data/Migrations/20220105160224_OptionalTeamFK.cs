using Microsoft.EntityFrameworkCore.Migrations;

namespace FCVoetbal.Data.Migrations
{
    public partial class OptionalTeamFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speler_Team_TeamID",
                table: "Speler");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Speler",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Speler_Team_TeamID",
                table: "Speler",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speler_Team_TeamID",
                table: "Speler");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Speler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Speler_Team_TeamID",
                table: "Speler",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
