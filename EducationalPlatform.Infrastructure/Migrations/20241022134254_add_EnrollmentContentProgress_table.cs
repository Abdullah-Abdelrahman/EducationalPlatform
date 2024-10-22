using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_EnrollmentContentProgress_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "ContentProgress",
                table: "Enrollments");

            migrationBuilder.CreateTable(
                name: "EnrollmentContentProgress",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentContentProgress", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_EnrollmentContentProgress_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentContentProgress_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentId",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentContentProgress_ContentId",
                table: "EnrollmentContentProgress",
                column: "ContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentContentProgress");



            migrationBuilder.AddColumn<string>(
                name: "ContentProgress",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");


        }
    }
}
