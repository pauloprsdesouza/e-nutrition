using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddAmputatedLimbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmputatedLimb",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Percentil = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmputatedLimb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmputatedLimbPatient",
                schema: "nutrinfo",
                columns: table => new
                {
                    AmputatedLimbsId = table.Column<int>(type: "integer", nullable: false),
                    PatientsUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmputatedLimbPatient", x => new { x.AmputatedLimbsId, x.PatientsUserId });
                    table.ForeignKey(
                        name: "FK_AmputatedLimbPatient_AmputatedLimb_AmputatedLimbsId",
                        column: x => x.AmputatedLimbsId,
                        principalSchema: "nutrinfo",
                        principalTable: "AmputatedLimb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmputatedLimbPatient_patient_PatientsUserId",
                        column: x => x.PatientsUserId,
                        principalSchema: "nutrinfo",
                        principalTable: "patient",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmputatedLimbPatient_PatientsUserId",
                schema: "nutrinfo",
                table: "AmputatedLimbPatient",
                column: "PatientsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmputatedLimbPatient",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "AmputatedLimb",
                schema: "nutrinfo");
        }
    }
}
