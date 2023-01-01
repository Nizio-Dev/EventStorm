using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class attendanceOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Meeting_MeetingId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Meeting_MeetingId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Categories_CategoryId",
                table: "Meeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_CategoryId",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Meeting");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "Meetings");

            migrationBuilder.AddColumn<string>(
                name: "OwnerIdId",
                table: "Meetings",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OwnerIdId",
                table: "Meetings",
                column: "OwnerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Meetings_MeetingId",
                table: "Attendances",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Meetings_MeetingId",
                table: "Categories",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Attenders_OwnerIdId",
                table: "Meetings",
                column: "OwnerIdId",
                principalTable: "Attenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Meetings_MeetingId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Meetings_MeetingId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Attenders_OwnerIdId",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_OwnerIdId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "OwnerIdId",
                table: "Meetings");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "Meeting");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Meeting",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_CategoryId",
                table: "Meeting",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Meeting_MeetingId",
                table: "Attendances",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Meeting_MeetingId",
                table: "Categories",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Categories_CategoryId",
                table: "Meeting",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
