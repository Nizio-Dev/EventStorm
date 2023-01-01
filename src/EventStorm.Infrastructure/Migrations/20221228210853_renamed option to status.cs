using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamedoptiontostatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Options_StatusId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Attenders_OwnerIdId",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "OwnerIdId",
                table: "Meetings",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_OwnerIdId",
                table: "Meetings",
                newName: "IX_Meetings_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Status_StatusId",
                table: "Attendances",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Attenders_OwnerId",
                table: "Meetings",
                column: "OwnerId",
                principalTable: "Attenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Status_StatusId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Attenders_OwnerId",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Options");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Meetings",
                newName: "OwnerIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_OwnerId",
                table: "Meetings",
                newName: "IX_Meetings_OwnerIdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Options_StatusId",
                table: "Attendances",
                column: "StatusId",
                principalTable: "Options",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Attenders_OwnerIdId",
                table: "Meetings",
                column: "OwnerIdId",
                principalTable: "Attenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
