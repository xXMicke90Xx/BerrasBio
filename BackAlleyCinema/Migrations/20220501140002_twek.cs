using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class twek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TakenSeats",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TakenSeats",
                table: "Schedules");
        }
    }
}
