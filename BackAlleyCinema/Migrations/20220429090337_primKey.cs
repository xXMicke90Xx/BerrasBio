using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class primKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                columns: new[] { "MovieId", "SaloonId", "ViewsId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                columns: new[] { "MovieId", "SaloonId" });
        }
    }
}
