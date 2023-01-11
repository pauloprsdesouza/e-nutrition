using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class ChangeNutritionalStateSeverityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NutritionalStateServerity",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "NutritionalStateSeverity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NutritionalStateSeverity",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "NutritionalStateServerity");
        }
    }
}
