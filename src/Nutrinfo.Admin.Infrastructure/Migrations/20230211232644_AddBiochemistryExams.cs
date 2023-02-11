using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddBiochemistryExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biochemistry",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HealthExam = table.Column<string>(type: "text", nullable: true),
                    MinimumThreshold = table.Column<double>(type: "double precision", nullable: false),
                    MaximumThreshold = table.Column<double>(type: "double precision", nullable: false),
                    PossibleMeanings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biochemistry", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "biochemistryExams",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "Biochemistry",
                schema: "nutrinfo");
        }
    }
}
