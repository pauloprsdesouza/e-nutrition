using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddBiochemistryResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "biochemistryExams",
                schema: "nutrinfo");

            migrationBuilder.AddColumn<int>(
                name: "BiochemistryId",
                schema: "nutrinfo",
                table: "evaluation",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "biochemistryResult",
                schema: "nutrinfo",
                columns: table => new
                {
                    BiochemistryId = table.Column<int>(type: "integer", nullable: false),
                    EvaluationId = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biochemistryResult", x => new { x.BiochemistryId, x.EvaluationId });
                    table.ForeignKey(
                        name: "FK_biochemistryResult_Biochemistry_BiochemistryId",
                        column: x => x.BiochemistryId,
                        principalSchema: "nutrinfo",
                        principalTable: "Biochemistry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_biochemistryResult_evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evaluation_BiochemistryId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "BiochemistryId");

            migrationBuilder.CreateIndex(
                name: "IX_biochemistryResult_EvaluationId",
                schema: "nutrinfo",
                table: "biochemistryResult",
                column: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluation_Biochemistry_BiochemistryId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "BiochemistryId",
                principalSchema: "nutrinfo",
                principalTable: "Biochemistry",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluation_Biochemistry_BiochemistryId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropTable(
                name: "biochemistryResult",
                schema: "nutrinfo");

            migrationBuilder.DropIndex(
                name: "IX_evaluation_BiochemistryId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "BiochemistryId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.CreateTable(
                name: "biochemistryExams",
                schema: "nutrinfo",
                columns: table => new
                {
                    BiochemistryExamsId = table.Column<int>(type: "integer", nullable: false),
                    EvaluationsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biochemistryExams", x => new { x.BiochemistryExamsId, x.EvaluationsId });
                    table.ForeignKey(
                        name: "FK_biochemistryExams_Biochemistry_BiochemistryExamsId",
                        column: x => x.BiochemistryExamsId,
                        principalSchema: "nutrinfo",
                        principalTable: "Biochemistry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_biochemistryExams_evaluation_EvaluationsId",
                        column: x => x.EvaluationsId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_biochemistryExams_EvaluationsId",
                schema: "nutrinfo",
                table: "biochemistryExams",
                column: "EvaluationsId");
        }
    }
}
