using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedtimesformeeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasEnded",
                table: "Meetings");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingTime",
                table: "Meetings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingTime",
                table: "Meetings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndingTime",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "StartingTime",
                table: "Meetings");

            migrationBuilder.AddColumn<bool>(
                name: "HasEnded",
                table: "Meetings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
