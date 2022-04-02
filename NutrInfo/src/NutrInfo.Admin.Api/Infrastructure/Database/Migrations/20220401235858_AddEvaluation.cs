using Microsoft.EntityFrameworkCore.Migrations;

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_nutritionist_NutritionistId",
                schema: "nutrinfo",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_patient_PatientId",
                schema: "nutrinfo",
                table: "Evaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluation",
                schema: "nutrinfo",
                table: "Evaluation");

            migrationBuilder.RenameTable(
                name: "Evaluation",
                schema: "nutrinfo",
                newName: "evaluation",
                newSchema: "nutrinfo");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_PatientId",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "IX_evaluation_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluation_NutritionistId",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "IX_evaluation_NutritionistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_evaluation",
                schema: "nutrinfo",
                table: "evaluation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluation_nutritionist_NutritionistId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "NutritionistId",
                principalSchema: "nutrinfo",
                principalTable: "nutritionist",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluation_patient_PatientId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "PatientId",
                principalSchema: "nutrinfo",
                principalTable: "patient",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluation_nutritionist_NutritionistId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluation_patient_PatientId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_evaluation",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.RenameTable(
                name: "evaluation",
                schema: "nutrinfo",
                newName: "Evaluation",
                newSchema: "nutrinfo");

            migrationBuilder.RenameIndex(
                name: "IX_evaluation_PatientId",
                schema: "nutrinfo",
                table: "Evaluation",
                newName: "IX_Evaluation_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_evaluation_NutritionistId",
                schema: "nutrinfo",
                table: "Evaluation",
                newName: "IX_Evaluation_NutritionistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluation",
                schema: "nutrinfo",
                table: "Evaluation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_nutritionist_NutritionistId",
                schema: "nutrinfo",
                table: "Evaluation",
                column: "NutritionistId",
                principalSchema: "nutrinfo",
                principalTable: "nutritionist",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_patient_PatientId",
                schema: "nutrinfo",
                table: "Evaluation",
                column: "PatientId",
                principalSchema: "nutrinfo",
                principalTable: "patient",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
