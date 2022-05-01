using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class tweks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Movies_MovieId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Saloons_SaloonId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TicketsSold",
                table: "Saloons");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_SaloonId",
                table: "Schedules",
                newName: "IX_Schedules_SaloonId");

            migrationBuilder.AddColumn<int>(
                name: "TicketsSold",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                columns: new[] { "MovieId", "SaloonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Movies_MovieId",
                table: "Schedules",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Saloons_SaloonId",
                table: "Schedules",
                column: "SaloonId",
                principalTable: "Saloons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Movies_MovieId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Saloons_SaloonId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TicketsSold",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_SaloonId",
                table: "Schedule",
                newName: "IX_Schedule_SaloonId");

            migrationBuilder.AddColumn<int>(
                name: "TicketsSold",
                table: "Saloons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                columns: new[] { "MovieId", "SaloonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Movies_MovieId",
                table: "Schedule",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Saloons_SaloonId",
                table: "Schedule",
                column: "SaloonId",
                principalTable: "Saloons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
