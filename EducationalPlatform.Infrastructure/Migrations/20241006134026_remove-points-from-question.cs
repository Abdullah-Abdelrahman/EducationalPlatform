using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removepointsfromquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fb307df-48b0-4cd9-ac13-18081aad1033");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9524be54-e4a8-42cd-9719-eeba3f244391");

            migrationBuilder.DropColumn(
                name: "points",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionImage",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "054f4f86-37c4-438f-a6c5-4141eb02afe0", null, "Admin", "ADMIN" },
                    { "db7e7a92-c218-4d5b-ae2e-2fc00f45d11d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "054f4f86-37c4-438f-a6c5-4141eb02afe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7e7a92-c218-4d5b-ae2e-2fc00f45d11d");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionImage",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "points",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fb307df-48b0-4cd9-ac13-18081aad1033", null, "Admin", null },
                    { "9524be54-e4a8-42cd-9719-eeba3f244391", null, "User", null }
                });
        }
    }
}
