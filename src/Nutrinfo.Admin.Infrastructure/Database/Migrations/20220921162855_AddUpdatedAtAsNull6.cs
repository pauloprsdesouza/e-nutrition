using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddUpdatedAtAsNull6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ArmCircumference",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ArmMuscleCircumference",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CalfCircumference",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TricepsPleat",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmCircumference",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "ArmMuscleCircumference",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "CalfCircumference",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "TricepsPleat",
                schema: "nutrinfo",
                table: "evaluation");
        }
    }
}
