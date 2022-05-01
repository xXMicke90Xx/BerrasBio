using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class removestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Saloons_Saloonid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Saloonid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Saloonid",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Saloonid",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Saloonid",
                table: "Movies",
                column: "Saloonid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Saloons_Saloonid",
                table: "Movies",
                column: "Saloonid",
                principalTable: "Saloons",
                principalColumn: "id");
        }
    }
}
