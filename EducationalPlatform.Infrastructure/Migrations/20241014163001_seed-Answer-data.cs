using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedAnswerdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a2791af-7873-46bf-a943-2b1eae1b6d10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f8317f-8c15-47a7-ac1b-b23af49c7241");

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "AnswerId", "AnswerText" },
                values: new object[,]
                {
                    { 1, "True" },
                    { 2, "False" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23ba435e-7713-47d6-a94f-2431b281a635", null, "User", "USER" },
                    { "625198ea-4a55-41ce-9122-74aeccbd8e59", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23ba435e-7713-47d6-a94f-2431b281a635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "625198ea-4a55-41ce-9122-74aeccbd8e59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a2791af-7873-46bf-a943-2b1eae1b6d10", null, "User", "USER" },
                    { "95f8317f-8c15-47a7-ac1b-b23af49c7241", null, "Admin", "ADMIN" }
                });
        }
    }
}
