using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddStepsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Steps",
                schema: "nutrinfo",
                table: "evaluation",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Steps",
                schema: "nutrinfo",
                table: "evaluation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
