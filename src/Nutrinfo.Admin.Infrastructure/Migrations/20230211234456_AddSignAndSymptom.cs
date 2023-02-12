using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddSignAndSymptom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossibleMeaning",
                schema: "nutrinfo",
                table: "clinicalChange");

            migrationBuilder.DropColumn(
                name: "SignsAndSymptoms",
                schema: "nutrinfo",
                table: "clinicalChange");

            migrationBuilder.CreateTable(
                name: "signAndSymptom",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClinicalChangeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PossibleMeanings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signAndSymptom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_signAndSymptom_clinicalChange_ClinicalChangeId",
                        column: x => x.ClinicalChangeId,
                        principalSchema: "nutrinfo",
                        principalTable: "clinicalChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_signAndSymptom_ClinicalChangeId",
                schema: "nutrinfo",
                table: "signAndSymptom",
                column: "ClinicalChangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "signAndSymptom",
                schema: "nutrinfo");

            migrationBuilder.AddColumn<string>(
                name: "PossibleMeaning",
                schema: "nutrinfo",
                table: "clinicalChange",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignsAndSymptoms",
                schema: "nutrinfo",
                table: "clinicalChange",
                type: "text",
                nullable: true);
        }
    }
}
