using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAsciticWeight",
                schema: "nutrinfo",
                table: "ascite",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPeripheralEdema",
                schema: "nutrinfo",
                table: "ascite",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAsciticWeight",
                schema: "nutrinfo",
                table: "ascite");

            migrationBuilder.DropColumn(
                name: "HasPeripheralEdema",
                schema: "nutrinfo",
                table: "ascite");
        }
    }
}
