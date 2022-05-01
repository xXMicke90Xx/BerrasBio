using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class more : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSaloon");

            migrationBuilder.AddColumn<int>(
                name: "TicketsSold",
                table: "Saloons",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Saloons_Saloonid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Saloonid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TicketsSold",
                table: "Saloons");

            migrationBuilder.DropColumn(
                name: "Saloonid",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieSaloon",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    Saloonsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSaloon", x => new { x.MoviesId, x.Saloonsid });
                    table.ForeignKey(
                        name: "FK_MovieSaloon_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSaloon_Saloons_Saloonsid",
                        column: x => x.Saloonsid,
                        principalTable: "Saloons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaloon_Saloonsid",
                table: "MovieSaloon",
                column: "Saloonsid");
        }
    }
}
