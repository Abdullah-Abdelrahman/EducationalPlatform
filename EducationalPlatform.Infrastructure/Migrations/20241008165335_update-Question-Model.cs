using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationalPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateQuestionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseQuestionAnswer_Answer_answerListAnswerId",
                table: "ChooseQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueOrFalseQuestionAnswer_Answer_answerListAnswerId",
                table: "TrueOrFalseQuestionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueOrFalseQuestionAnswer",
                table: "TrueOrFalseQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_TrueOrFalseQuestionAnswer_answerListAnswerId",
                table: "TrueOrFalseQuestionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChooseQuestionAnswer",
                table: "ChooseQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ChooseQuestionAnswer_answerListAnswerId",
                table: "ChooseQuestionAnswer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068492e0-d4a5-4653-b20c-6385bb54d607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c579f6e0-6079-4a97-ab1b-c2211bf2ac0f");

            migrationBuilder.DropColumn(
                name: "TrueOrFalseQuestion_correctAnswerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "correctAnswer",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "answerListAnswerId",
                table: "TrueOrFalseQuestionAnswer",
                newName: "ChoiceListAnswerId");

            migrationBuilder.RenameColumn(
                name: "correctAnswerId",
                table: "Questions",
                newName: "CorrectAnswerId");

            migrationBuilder.RenameColumn(
                name: "answerListAnswerId",
                table: "ChooseQuestionAnswer",
                newName: "ChoiceListAnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "CorrectAnswerId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueOrFalseQuestionAnswer",
                table: "TrueOrFalseQuestionAnswer",
                columns: new[] { "ChoiceListAnswerId", "TrueOrFalseQuestionsQuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseQuestionAnswer",
                table: "ChooseQuestionAnswer",
                columns: new[] { "ChoiceListAnswerId", "ChooseQuestionsQuestionId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bf80e93-b64b-4ef7-aa51-b6908d2efd29", null, "Admin", "ADMIN" },
                    { "f7f685c6-d303-4000-a152-ac9d7b514bb9", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrueOrFalseQuestionAnswer_TrueOrFalseQuestionsQuestionId",
                table: "TrueOrFalseQuestionAnswer",
                column: "TrueOrFalseQuestionsQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChooseQuestionAnswer_ChooseQuestionsQuestionId",
                table: "ChooseQuestionAnswer",
                column: "ChooseQuestionsQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseQuestionAnswer_Answer_ChoiceListAnswerId",
                table: "ChooseQuestionAnswer",
                column: "ChoiceListAnswerId",
                principalTable: "Answer",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answer_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId",
                principalTable: "Answer",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueOrFalseQuestionAnswer_Answer_ChoiceListAnswerId",
                table: "TrueOrFalseQuestionAnswer",
                column: "ChoiceListAnswerId",
                principalTable: "Answer",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseQuestionAnswer_Answer_ChoiceListAnswerId",
                table: "ChooseQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answer_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueOrFalseQuestionAnswer_Answer_ChoiceListAnswerId",
                table: "TrueOrFalseQuestionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueOrFalseQuestionAnswer",
                table: "TrueOrFalseQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_TrueOrFalseQuestionAnswer_TrueOrFalseQuestionsQuestionId",
                table: "TrueOrFalseQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChooseQuestionAnswer",
                table: "ChooseQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ChooseQuestionAnswer_ChooseQuestionsQuestionId",
                table: "ChooseQuestionAnswer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bf80e93-b64b-4ef7-aa51-b6908d2efd29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7f685c6-d303-4000-a152-ac9d7b514bb9");

            migrationBuilder.RenameColumn(
                name: "ChoiceListAnswerId",
                table: "TrueOrFalseQuestionAnswer",
                newName: "answerListAnswerId");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswerId",
                table: "Questions",
                newName: "correctAnswerId");

            migrationBuilder.RenameColumn(
                name: "ChoiceListAnswerId",
                table: "ChooseQuestionAnswer",
                newName: "answerListAnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "correctAnswerId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TrueOrFalseQuestion_correctAnswerId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "correctAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueOrFalseQuestionAnswer",
                table: "TrueOrFalseQuestionAnswer",
                columns: new[] { "TrueOrFalseQuestionsQuestionId", "answerListAnswerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseQuestionAnswer",
                table: "ChooseQuestionAnswer",
                columns: new[] { "ChooseQuestionsQuestionId", "answerListAnswerId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068492e0-d4a5-4653-b20c-6385bb54d607", null, "User", "USER" },
                    { "c579f6e0-6079-4a97-ab1b-c2211bf2ac0f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrueOrFalseQuestionAnswer_answerListAnswerId",
                table: "TrueOrFalseQuestionAnswer",
                column: "answerListAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChooseQuestionAnswer_answerListAnswerId",
                table: "ChooseQuestionAnswer",
                column: "answerListAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseQuestionAnswer_Answer_answerListAnswerId",
                table: "ChooseQuestionAnswer",
                column: "answerListAnswerId",
                principalTable: "Answer",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueOrFalseQuestionAnswer_Answer_answerListAnswerId",
                table: "TrueOrFalseQuestionAnswer",
                column: "answerListAnswerId",
                principalTable: "Answer",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
