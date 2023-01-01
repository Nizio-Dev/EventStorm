using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fluentapiadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Attenders_AttenderId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Meeting_MeetingId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attenders_Meeting_MeetingId",
                table: "Attenders");

            migrationBuilder.DropIndex(
                name: "IX_Attenders_MeetingId",
                table: "Attenders");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Attenders");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Meeting",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "MeetingId",
                keyValue: null,
                column: "MeetingId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingId",
                table: "Attendances",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "AttenderId",
                keyValue: null,
                column: "AttenderId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AttenderId",
                table: "Attendances",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_CategoryId",
                table: "Meeting",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Attenders_AttenderId",
                table: "Attendances",
                column: "AttenderId",
                principalTable: "Attenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Meeting_MeetingId",
                table: "Attendances",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Categories_CategoryId",
                table: "Meeting",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Attenders_AttenderId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Meeting_MeetingId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Categories_CategoryId",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_CategoryId",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Meeting");

            migrationBuilder.AddColumn<string>(
                name: "MeetingId",
                table: "Attenders",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingId",
                table: "Attendances",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AttenderId",
                table: "Attendances",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Attenders_MeetingId",
                table: "Attenders",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Attenders_AttenderId",
                table: "Attendances",
                column: "AttenderId",
                principalTable: "Attenders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Meeting_MeetingId",
                table: "Attendances",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attenders_Meeting_MeetingId",
                table: "Attenders",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id");
        }
    }
}
