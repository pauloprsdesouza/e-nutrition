using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class RemoveFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedNumber",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "Energy",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.RenameColumn(
                name: "Protein",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "LostWeightLastThreeMonths");

            migrationBuilder.RenameColumn(
                name: "NutritionState",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "NutritionalState");

            migrationBuilder.AddColumn<bool>(
                name: "ReducedDietaryIntake",
                schema: "nutrinfo",
                table: "evaluation",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SeriouslyIllPatient",
                schema: "nutrinfo",
                table: "evaluation",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Steps",
                schema: "nutrinfo",
                table: "evaluation",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReducedDietaryIntake",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "SeriouslyIllPatient",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.DropColumn(
                name: "Steps",
                schema: "nutrinfo",
                table: "evaluation");

            migrationBuilder.RenameColumn(
                name: "NutritionalState",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "NutritionState");

            migrationBuilder.RenameColumn(
                name: "LostWeightLastThreeMonths",
                schema: "nutrinfo",
                table: "evaluation",
                newName: "Protein");

            migrationBuilder.AddColumn<int>(
                name: "BedNumber",
                schema: "nutrinfo",
                table: "evaluation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Energy",
                schema: "nutrinfo",
                table: "evaluation",
                type: "double precision",
                nullable: true);
        }
    }
}
