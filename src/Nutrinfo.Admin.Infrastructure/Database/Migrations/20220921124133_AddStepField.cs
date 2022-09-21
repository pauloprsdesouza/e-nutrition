using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddStepField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Steps",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "Step");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Step",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "Steps");
        }
    }
}
