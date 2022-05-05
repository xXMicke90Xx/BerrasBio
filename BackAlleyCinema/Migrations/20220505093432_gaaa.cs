using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class gaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleMovieId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleSaloonId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleViewsId",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets",
                columns: new[] { "ScheduleMovieId", "ScheduleSaloonId", "ScheduleViewsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Schedules_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets",
                columns: new[] { "ScheduleMovieId", "ScheduleSaloonId", "ScheduleViewsId" },
                principalTable: "Schedules",
                principalColumns: new[] { "MovieId", "SaloonId", "ViewsId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Schedules_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScheduleMovieId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScheduleSaloonId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScheduleViewsId",
                table: "Tickets");
        }
    }
}
