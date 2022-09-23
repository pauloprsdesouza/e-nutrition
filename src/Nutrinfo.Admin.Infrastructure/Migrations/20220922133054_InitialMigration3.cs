using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluation_ascitedegree_AsciteDegreeId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropIndex(
                name: "IX_evaluation_AsciteDegreeId",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "AsciteDegreeId",
                schema: "nutrinfo",
                table: "evaluation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsciteDegreeId",
                schema: "nutrinfo",
                table: "evaluation",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_evaluation_AsciteDegreeId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "AsciteDegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluation_ascitedegree_AsciteDegreeId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "AsciteDegreeId",
                principalSchema: "nutrinfo",
                principalTable: "ascitedegree",
                principalColumn: "Id");
        }
    }
}
