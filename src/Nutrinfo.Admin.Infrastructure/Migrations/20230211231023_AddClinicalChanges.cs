using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddClinicalChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluationSemiologies_NutritionalStateSemiology_Semiologies~",
                schema: "nutrinfo",
                table: "evaluationSemiologies");

            migrationBuilder.DropForeignKey(
                name: "FK_NutritionalStateSemiology_Semiology_SemiologyId",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semiology",
                schema: "nutrinfo",
                table: "Semiology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutritionalStateSemiology",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology");

            migrationBuilder.RenameTable(
                name: "Semiology",
                schema: "nutrinfo",
                newName: "semiology",
                newSchema: "nutrinfo");

            migrationBuilder.RenameTable(
                name: "NutritionalStateSemiology",
                schema: "nutrinfo",
                newName: "nutritionalStateSemiology",
                newSchema: "nutrinfo");

            migrationBuilder.RenameIndex(
                name: "IX_NutritionalStateSemiology_SemiologyId",
                schema: "nutrinfo",
                table: "nutritionalStateSemiology",
                newName: "IX_nutritionalStateSemiology_SemiologyId");

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                schema: "nutrinfo",
                table: "semiology",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "NutritionalState",
                schema: "nutrinfo",
                table: "nutritionalStateSemiology",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_semiology",
                schema: "nutrinfo",
                table: "semiology",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nutritionalStateSemiology",
                schema: "nutrinfo",
                table: "nutritionalStateSemiology",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "clinicalChange",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BodyRegion = table.Column<string>(type: "text", nullable: true),
                    SignsAndSymptoms = table.Column<string>(type: "text", nullable: true),
                    PossibleMeaning = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicalChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clinicalChanges",
                schema: "nutrinfo",
                columns: table => new
                {
                    ClinicalChangesId = table.Column<int>(type: "integer", nullable: false),
                    EvaluationsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicalChanges", x => new { x.ClinicalChangesId, x.EvaluationsId });
                    table.ForeignKey(
                        name: "FK_clinicalChanges_clinicalChange_ClinicalChangesId",
                        column: x => x.ClinicalChangesId,
                        principalSchema: "nutrinfo",
                        principalTable: "clinicalChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinicalChanges_evaluation_EvaluationsId",
                        column: x => x.EvaluationsId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clinicalChanges_EvaluationsId",
                schema: "nutrinfo",
                table: "clinicalChanges",
                column: "EvaluationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluationSemiologies_nutritionalStateSemiology_Semiologies~",
                schema: "nutrinfo",
                table: "evaluationSemiologies",
                column: "SemiologiesId",
                principalSchema: "nutrinfo",
                principalTable: "nutritionalStateSemiology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nutritionalStateSemiology_semiology_SemiologyId",
                schema: "nutrinfo",
                table: "nutritionalStateSemiology",
                column: "SemiologyId",
                principalSchema: "nutrinfo",
                principalTable: "semiology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluationSemiologies_nutritionalStateSemiology_Semiologies~",
                schema: "nutrinfo",
                table: "evaluationSemiologies");

            migrationBuilder.DropForeignKey(
                name: "FK_nutritionalStateSemiology_semiology_SemiologyId",
                schema: "nutrinfo",
                table: "nutritionalStateSemiology");

            migrationBuilder.DropTable(
                name: "clinicalChanges",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "clinicalChange",
                schema: "nutrinfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_semiology",
                schema: "nutrinfo",
                table: "semiology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nutritionalStateSemiology",
                schema: "nutrinfo",
                table: "nutritionalStateSemiology");

            migrationBuilder.RenameTable(
                name: "semiology",
                schema: "nutrinfo",
                newName: "Semiology",
                newSchema: "nutrinfo");

            migrationBuilder.RenameTable(
                name: "nutritionalStateSemiology",
                schema: "nutrinfo",
                newName: "NutritionalStateSemiology",
                newSchema: "nutrinfo");

            migrationBuilder.RenameIndex(
                name: "IX_nutritionalStateSemiology_SemiologyId",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology",
                newName: "IX_NutritionalStateSemiology_SemiologyId");

            migrationBuilder.AlterColumn<int>(
                name: "Group",
                schema: "nutrinfo",
                table: "Semiology",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "NutritionalState",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semiology",
                schema: "nutrinfo",
                table: "Semiology",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutritionalStateSemiology",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluationSemiologies_NutritionalStateSemiology_Semiologies~",
                schema: "nutrinfo",
                table: "evaluationSemiologies",
                column: "SemiologiesId",
                principalSchema: "nutrinfo",
                principalTable: "NutritionalStateSemiology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionalStateSemiology_Semiology_SemiologyId",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology",
                column: "SemiologyId",
                principalSchema: "nutrinfo",
                principalTable: "Semiology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
