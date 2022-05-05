using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    public partial class wer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Schedules_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Tickets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleViewsId",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleSaloonId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleMovieId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Schedules_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets",
                columns: new[] { "ScheduleMovieId", "ScheduleSaloonId", "ScheduleViewsId" },
                principalTable: "Schedules",
                principalColumns: new[] { "MovieId", "SaloonId", "ViewsId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Schedules_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleViewsId",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleSaloonId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleMovieId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Schedules_ScheduleMovieId_ScheduleSaloonId_ScheduleViewsId",
                table: "Tickets",
                columns: new[] { "ScheduleMovieId", "ScheduleSaloonId", "ScheduleViewsId" },
                principalTable: "Schedules",
                principalColumns: new[] { "MovieId", "SaloonId", "ViewsId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
