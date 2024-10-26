using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_QuizQuestionAnswer_key_to_SubmitId_plus_QuestionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_quizQuestionAnswers",
                table: "quizQuestionAnswers");



            migrationBuilder.AddPrimaryKey(
                name: "PK_quizQuestionAnswers",
                table: "quizQuestionAnswers",
                columns: new[] { "SubmitId", "QuestionId" });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_quizQuestionAnswers",
                table: "quizQuestionAnswers");


            migrationBuilder.AddPrimaryKey(
                name: "PK_quizQuestionAnswers",
                table: "quizQuestionAnswers",
                column: "SubmitId");


        }
    }
}
