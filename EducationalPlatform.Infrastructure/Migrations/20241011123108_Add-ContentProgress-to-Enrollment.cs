using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContentProgresstoEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04656cf8-8109-4b7d-9028-8dbf6773054c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebde7126-6289-46ab-9511-0239bab2f9a3");

            migrationBuilder.AddColumn<string>(
                name: "ContentProgress",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e4f7d3b0-2a8b-4877-a2ce-dfcbb61ef715", null, "User", "USER" },
                    { "f00f2d8f-1ddb-428d-93af-f09c165331d1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f7d3b0-2a8b-4877-a2ce-dfcbb61ef715");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f00f2d8f-1ddb-428d-93af-f09c165331d1");

            migrationBuilder.DropColumn(
                name: "ContentProgress",
                table: "Enrollments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04656cf8-8109-4b7d-9028-8dbf6773054c", null, "User", "USER" },
                    { "ebde7126-6289-46ab-9511-0239bab2f9a3", null, "Admin", "ADMIN" }
                });
        }
    }
}
