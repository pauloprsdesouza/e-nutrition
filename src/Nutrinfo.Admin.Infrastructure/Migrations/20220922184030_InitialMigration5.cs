using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class InitialMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                schema: "nutrinfo",
                table: "ascitedegree",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                schema: "nutrinfo",
                table: "ascitedegree",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
