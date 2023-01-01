using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedmaxattenders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxAttenders",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAttenders",
                table: "Meetings");
        }
    }
}
