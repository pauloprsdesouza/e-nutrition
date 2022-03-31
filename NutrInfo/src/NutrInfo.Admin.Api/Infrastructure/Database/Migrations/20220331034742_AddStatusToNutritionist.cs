using Microsoft.EntityFrameworkCore.Migrations;

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddStatusToNutritionist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "nutrinfo",
                table: "nutritionist",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "nutrinfo",
                table: "nutritionist");
        }
    }
}
