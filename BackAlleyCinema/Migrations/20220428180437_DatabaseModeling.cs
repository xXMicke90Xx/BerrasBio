using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class DatabaseModeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saloons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaloonNr = table.Column<int>(type: "int", nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloons", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    SaloonId = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => new { x.MovieId, x.SaloonId });
                    table.ForeignKey(
                        name: "FK_Schedule_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_Saloons_SaloonId",
                        column: x => x.SaloonId,
                        principalTable: "Saloons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaloon_Saloonsid",
                table: "MovieSaloon",
                column: "Saloonsid");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SaloonId",
                table: "Schedule",
                column: "SaloonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSaloon");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Saloons");
        }
    }
}
