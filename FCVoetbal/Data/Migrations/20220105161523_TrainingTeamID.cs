using Microsoft.EntityFrameworkCore.Migrations;

namespace FCVoetbal.Data.Migrations
{
    public partial class TrainingTeamID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_Team_TeamID",
                table: "Training");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Training",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Team_TeamID",
                table: "Training",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_Team_TeamID",
                table: "Training");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Training",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Team_TeamID",
                table: "Training",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
