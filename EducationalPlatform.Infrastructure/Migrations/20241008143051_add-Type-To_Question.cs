using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTypeTo_Question : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "054f4f86-37c4-438f-a6c5-4141eb02afe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7e7a92-c218-4d5b-ae2e-2fc00f45d11d");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068492e0-d4a5-4653-b20c-6385bb54d607", null, "User", "USER" },
                    { "c579f6e0-6079-4a97-ab1b-c2211bf2ac0f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068492e0-d4a5-4653-b20c-6385bb54d607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c579f6e0-6079-4a97-ab1b-c2211bf2ac0f");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "054f4f86-37c4-438f-a6c5-4141eb02afe0", null, "Admin", "ADMIN" },
                    { "db7e7a92-c218-4d5b-ae2e-2fc00f45d11d", null, "User", "USER" }
                });
        }
    }
}
