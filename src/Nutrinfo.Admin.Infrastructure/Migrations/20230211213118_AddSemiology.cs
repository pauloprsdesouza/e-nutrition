using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddSemiology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountedWeight",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "P95",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P90",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P85",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P75",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P50",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P5",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P25",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P15",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "P10",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.CreateTable(
                name: "Semiology",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hint = table.Column<string>(type: "text", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semiology", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalStateSemiology",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SemiologyId = table.Column<int>(type: "integer", nullable: false),
                    NutritionalState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalStateSemiology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionalStateSemiology_Semiology_SemiologyId",
                        column: x => x.SemiologyId,
                        principalSchema: "nutrinfo",
                        principalTable: "Semiology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evaluationSemiologies",
                schema: "nutrinfo",
                columns: table => new
                {
                    EvaluationsId = table.Column<int>(type: "integer", nullable: false),
                    SemiologiesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluationSemiologies", x => new { x.EvaluationsId, x.SemiologiesId });
                    table.ForeignKey(
                        name: "FK_evaluationSemiologies_evaluation_EvaluationsId",
                        column: x => x.EvaluationsId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_evaluationSemiologies_NutritionalStateSemiology_Semiologies~",
                        column: x => x.SemiologiesId,
                        principalSchema: "nutrinfo",
                        principalTable: "NutritionalStateSemiology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evaluationSemiologies_SemiologiesId",
                schema: "nutrinfo",
                table: "evaluationSemiologies",
                column: "SemiologiesId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalStateSemiology_SemiologyId",
                schema: "nutrinfo",
                table: "NutritionalStateSemiology",
                column: "SemiologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evaluationSemiologies",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "NutritionalStateSemiology",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "Semiology",
                schema: "nutrinfo");

            migrationBuilder.DropColumn(
                name: "DiscountedWeight",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.AlterColumn<decimal>(
                name: "P95",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P90",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P85",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P75",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P50",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P5",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P25",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P15",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "P10",
                schema: "nutrinfo",
                table: "armCircumferencePercentil",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
