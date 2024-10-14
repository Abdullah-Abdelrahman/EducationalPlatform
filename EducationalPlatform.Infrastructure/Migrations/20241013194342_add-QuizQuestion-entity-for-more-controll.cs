using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addQuizQuestionentityformorecontroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Content_QuizsContentId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Questions_QuizQuestionsQuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_QuizsContentId",
                table: "QuizQuestion");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a47f042-0bcb-4cbc-b4ac-f2797edbd39c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "754be543-b682-4ae0-ac74-f518f7c9813e");

            migrationBuilder.RenameColumn(
                name: "QuizsContentId",
                table: "QuizQuestion",
                newName: "Points");

            migrationBuilder.RenameColumn(
                name: "QuizQuestionsQuestionId",
                table: "QuizQuestion",
                newName: "QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "QuizQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion",
                columns: new[] { "QuizId", "QuestionId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a2791af-7873-46bf-a943-2b1eae1b6d10", null, "User", "USER" },
                    { "95f8317f-8c15-47a7-ac1b-b23af49c7241", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Content_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId",
                principalTable: "Content",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Questions_QuizId",
                table: "QuizQuestion",
                column: "QuizId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Content_QuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Questions_QuizId",
                table: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a2791af-7873-46bf-a943-2b1eae1b6d10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f8317f-8c15-47a7-ac1b-b23af49c7241");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "QuizQuestion");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "QuizQuestion",
                newName: "QuizsContentId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "QuizQuestion",
                newName: "QuizQuestionsQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion",
                columns: new[] { "QuizQuestionsQuestionId", "QuizsContentId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a47f042-0bcb-4cbc-b4ac-f2797edbd39c", null, "Admin", "ADMIN" },
                    { "754be543-b682-4ae0-ac74-f518f7c9813e", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuizsContentId",
                table: "QuizQuestion",
                column: "QuizsContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Content_QuizsContentId",
                table: "QuizQuestion",
                column: "QuizsContentId",
                principalTable: "Content",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Questions_QuizQuestionsQuestionId",
                table: "QuizQuestion",
                column: "QuizQuestionsQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
