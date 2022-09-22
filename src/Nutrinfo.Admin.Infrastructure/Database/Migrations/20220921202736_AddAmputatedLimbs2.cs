using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddAmputatedLimbs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmputatedLimbPatient",
                schema: "nutrinfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmputatedLimb",
                schema: "nutrinfo",
                table: "AmputatedLimb");

            migrationBuilder.RenameTable(
                name: "AmputatedLimb",
                schema: "nutrinfo",
                newName: "amputatedlimb",
                newSchema: "nutrinfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_amputatedlimb",
                schema: "nutrinfo",
                table: "amputatedlimb",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "amputatedlimbs",
                schema: "nutrinfo",
                columns: table => new
                {
                    AmputatedLimbsId = table.Column<int>(type: "integer", nullable: false),
                    PatientsUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimbs", x => new { x.AmputatedLimbsId, x.PatientsUserId });
                    table.ForeignKey(
                        name: "FK_amputatedlimbs_amputatedlimb_AmputatedLimbsId",
                        column: x => x.AmputatedLimbsId,
                        principalSchema: "nutrinfo",
                        principalTable: "amputatedlimb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_amputatedlimbs_patient_PatientsUserId",
                        column: x => x.PatientsUserId,
                        principalSchema: "nutrinfo",
                        principalTable: "patient",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimb_Name",
                schema: "nutrinfo",
                table: "amputatedlimb",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimbs_PatientsUserId",
                schema: "nutrinfo",
                table: "amputatedlimbs",
                column: "PatientsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amputatedlimbs",
                schema: "nutrinfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_amputatedlimb",
                schema: "nutrinfo",
                table: "amputatedlimb");

            migrationBuilder.DropIndex(
                name: "IX_amputatedlimb_Name",
                schema: "nutrinfo",
                table: "amputatedlimb");

            migrationBuilder.RenameTable(
                name: "amputatedlimb",
                schema: "nutrinfo",
                newName: "AmputatedLimb",
                newSchema: "nutrinfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmputatedLimb",
                schema: "nutrinfo",
                table: "AmputatedLimb",
                column: "Id");

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
    }
}
