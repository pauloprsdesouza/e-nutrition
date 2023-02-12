using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddBodyRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BodyRegion",
                schema: "nutrinfo",
                table: "semiology",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyRegion",
                schema: "nutrinfo",
                table: "semiology");
        }
    }
}
