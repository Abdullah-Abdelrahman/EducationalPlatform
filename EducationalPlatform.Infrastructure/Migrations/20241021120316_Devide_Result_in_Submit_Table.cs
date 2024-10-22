using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Devide_Result_in_Submit_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.RenameColumn(
                name: "result",
                table: "submits",
                newName: "Totalresult");

            migrationBuilder.AddColumn<int>(
                name: "Partialresult",
                table: "submits",
                type: "int",
                nullable: true);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "Partialresult",
                table: "submits");

            migrationBuilder.RenameColumn(
                name: "Totalresult",
                table: "submits",
                newName: "result");


        }
    }
}
