using Microsoft.EntityFrameworkCore.Migrations;

namespace FCVoetbal.Data.Migrations
{
    public partial class RedoGebruiker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GebruikerID",
                table: "GebruikerMatch",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefoon",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerMatch_GebruikerID",
                table: "GebruikerMatch",
                column: "GebruikerID");

            migrationBuilder.AddForeignKey(
                name: "FK_GebruikerMatch_AspNetUsers_GebruikerID",
                table: "GebruikerMatch",
                column: "GebruikerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GebruikerMatch_AspNetUsers_GebruikerID",
                table: "GebruikerMatch");

            migrationBuilder.DropIndex(
                name: "IX_GebruikerMatch_GebruikerID",
                table: "GebruikerMatch");

            migrationBuilder.DropColumn(
                name: "GebruikerID",
                table: "GebruikerMatch");

            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefoon",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
