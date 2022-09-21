using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddUpdatedAtAsNull5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LostWeightLastThreeMonths",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LostWeightLastThreeMonths",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
