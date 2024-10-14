using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContentFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f7d3b0-2a8b-4877-a2ce-dfcbb61ef715");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f00f2d8f-1ddb-428d-93af-f09c165331d1");

            migrationBuilder.RenameColumn(
                name: "File",
                table: "Content",
                newName: "PathName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "723f5ccd-e274-4e20-ae58-b47afda7952b", null, "User", "USER" },
                    { "cb882631-b0fc-4c3b-9218-a22d77337a2b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "723f5ccd-e274-4e20-ae58-b47afda7952b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb882631-b0fc-4c3b-9218-a22d77337a2b");

            migrationBuilder.RenameColumn(
                name: "PathName",
                table: "Content",
                newName: "File");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e4f7d3b0-2a8b-4877-a2ce-dfcbb61ef715", null, "User", "USER" },
                    { "f00f2d8f-1ddb-428d-93af-f09c165331d1", null, "Admin", "ADMIN" }
                });
        }
    }
}
