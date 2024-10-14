using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeChoiceListfromTrueOrFalseQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrueOrFalseQuestionAnswer");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TrueOrFalseQuestionAnswer",
                columns: table => new
                {
                    ChoiceListAnswerId = table.Column<int>(type: "int", nullable: false),
                    TrueOrFalseQuestionsQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueOrFalseQuestionAnswer", x => new { x.ChoiceListAnswerId, x.TrueOrFalseQuestionsQuestionId });
                    table.ForeignKey(
                        name: "FK_TrueOrFalseQuestionAnswer_Answer_ChoiceListAnswerId",
                        column: x => x.ChoiceListAnswerId,
                        principalTable: "Answer",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrueOrFalseQuestionAnswer_Questions_TrueOrFalseQuestionsQuestionId",
                        column: x => x.TrueOrFalseQuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_TrueOrFalseQuestionAnswer_TrueOrFalseQuestionsQuestionId",
                table: "TrueOrFalseQuestionAnswer",
                column: "TrueOrFalseQuestionsQuestionId");
        }
    }
}
