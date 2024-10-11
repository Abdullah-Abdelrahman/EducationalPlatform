using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changecolumnnamefromtypetoQuestionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bf80e93-b64b-4ef7-aa51-b6908d2efd29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7f685c6-d303-4000-a152-ac9d7b514bb9");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Questions",
                newName: "QuestionType");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04656cf8-8109-4b7d-9028-8dbf6773054c", null, "User", "USER" },
                    { "ebde7126-6289-46ab-9511-0239bab2f9a3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04656cf8-8109-4b7d-9028-8dbf6773054c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebde7126-6289-46ab-9511-0239bab2f9a3");

            migrationBuilder.RenameColumn(
                name: "QuestionType",
                table: "Questions",
                newName: "type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bf80e93-b64b-4ef7-aa51-b6908d2efd29", null, "Admin", "ADMIN" },
                    { "f7f685c6-d303-4000-a152-ac9d7b514bb9", null, "User", "USER" }
                });
        }
    }
}
