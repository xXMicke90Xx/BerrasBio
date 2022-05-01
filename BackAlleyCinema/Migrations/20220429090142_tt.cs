using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Views",
                table: "Schedules",
                newName: "ViewsId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Saloons",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewsId",
                table: "Schedules",
                newName: "Views");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Saloons",
                newName: "id");
        }
    }
}
