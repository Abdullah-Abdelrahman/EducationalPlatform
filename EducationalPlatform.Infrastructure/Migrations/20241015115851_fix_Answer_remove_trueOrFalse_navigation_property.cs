using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_Answer_remove_trueOrFalse_navigation_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Questions_Answer_AnswerId",
            //    table: "Questions");

            //migrationBuilder.DropIndex(
            //    name: "IX_Questions_AnswerId",
            //    table: "Questions");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "3b47b88e-23d5-4fad-9339-8399f5b696de");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "7fdc9615-4452-4c10-b9b4-9840ca4c3a55");

            ////migrationBuilder.DropColumn(
            ////    name: "AnswerId",
            ////    table: "Questions");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "e37bf1cd-e299-4d23-a8bd-bd4a714fc249", null, "User", "USER" },
            //        { "f77364f2-ab97-4dec-b67b-0ea8109ead35", null, "Admin", "ADMIN" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "e37bf1cd-e299-4d23-a8bd-bd4a714fc249");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "f77364f2-ab97-4dec-b67b-0ea8109ead35");

            //migrationBuilder.AddColumn<int>(
            //    name: "AnswerId",
            //    table: "Questions",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "3b47b88e-23d5-4fad-9339-8399f5b696de", null, "User", "USER" },
            //        { "7fdc9615-4452-4c10-b9b4-9840ca4c3a55", null, "Admin", "ADMIN" }
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Questions_AnswerId",
            //    table: "Questions",
            //    column: "AnswerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Questions_Answer_AnswerId",
            //    table: "Questions",
            //    column: "AnswerId",
            //    principalTable: "Answer",
            //    principalColumn: "AnswerId");
        }
    }
}
