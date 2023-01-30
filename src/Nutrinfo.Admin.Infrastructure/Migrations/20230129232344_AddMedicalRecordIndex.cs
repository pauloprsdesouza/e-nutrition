using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddMedicalRecordIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_Email",
                schema: "nutrinfo",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_patient_MedicalRecord",
                schema: "nutrinfo",
                table: "patient",
                column: "MedicalRecord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_patient_MedicalRecord",
                schema: "nutrinfo",
                table: "patient");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                schema: "nutrinfo",
                table: "user",
                column: "Email",
                unique: true);
        }
    }
}
