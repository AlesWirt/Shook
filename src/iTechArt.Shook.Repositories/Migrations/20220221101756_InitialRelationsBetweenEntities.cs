using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArt.Shook.Repositories.Migrations
{
    public partial class InitialRelationsBetweenEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Survey",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "QuestionBody",
                table: "Question",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Survey",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_OwnerId",
                table: "Survey",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_User_OwnerId",
                table: "Survey",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Survey_User_OwnerId",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_OwnerId",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Survey");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Survey",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Question",
                newName: "QuestionBody");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
