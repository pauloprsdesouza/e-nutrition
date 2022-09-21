using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddWeightEdemaAndAscite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amputatedlimbs",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "amputatedlimb",
                schema: "nutrinfo");

            migrationBuilder.DropColumn(
                name: "HasAmputatedLimb",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "HasEdema",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.AddColumn<double>(
                name: "AsciteWeight",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EdemaWeight",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsciteWeight",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "EdemaWeight",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.AddColumn<bool>(
                name: "HasAmputatedLimb",
                schema: "nutrinfo",
                table: "evaluation",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdema",
                schema: "nutrinfo",
                table: "evaluation",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "amputatedlimb",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Limb = table.Column<string>(type: "text", nullable: true),
                    Percentual = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "amputatedlimbs",
                schema: "nutrinfo",
                columns: table => new
                {
                    AmputatedLimbsId = table.Column<int>(type: "integer", nullable: false),
                    EvaluationsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimbs", x => new { x.AmputatedLimbsId, x.EvaluationsId });
                    table.ForeignKey(
                        name: "FK_amputatedlimbs_amputatedlimb_AmputatedLimbsId",
                        column: x => x.AmputatedLimbsId,
                        principalSchema: "nutrinfo",
                        principalTable: "amputatedlimb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_amputatedlimbs_evaluation_EvaluationsId",
                        column: x => x.EvaluationsId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimbs_EvaluationsId",
                schema: "nutrinfo",
                table: "amputatedlimbs",
                column: "EvaluationsId");
        }
    }
}
