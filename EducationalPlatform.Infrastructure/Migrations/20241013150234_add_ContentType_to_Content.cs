using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_ContentType_to_Content : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "723f5ccd-e274-4e20-ae58-b47afda7952b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb882631-b0fc-4c3b-9218-a22d77337a2b");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a47f042-0bcb-4cbc-b4ac-f2797edbd39c", null, "Admin", "ADMIN" },
                    { "754be543-b682-4ae0-ac74-f518f7c9813e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a47f042-0bcb-4cbc-b4ac-f2797edbd39c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "754be543-b682-4ae0-ac74-f518f7c9813e");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Content");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "723f5ccd-e274-4e20-ae58-b47afda7952b", null, "User", "USER" },
                    { "cb882631-b0fc-4c3b-9218-a22d77337a2b", null, "Admin", "ADMIN" }
                });
        }
    }
}
