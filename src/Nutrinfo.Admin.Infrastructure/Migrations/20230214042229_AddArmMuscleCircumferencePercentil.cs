using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddArmMuscleCircumferencePercentil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "armMuscleCircumferencePercentil",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartAge = table.Column<int>(type: "integer", nullable: false),
                    EndAge = table.Column<int>(type: "integer", nullable: false),
                    P5 = table.Column<double>(type: "double precision", nullable: false),
                    P10 = table.Column<double>(type: "double precision", nullable: false),
                    P25 = table.Column<double>(type: "double precision", nullable: false),
                    P50 = table.Column<double>(type: "double precision", nullable: false),
                    P75 = table.Column<double>(type: "double precision", nullable: false),
                    P90 = table.Column<double>(type: "double precision", nullable: false),
                    P95 = table.Column<double>(type: "double precision", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    IsAged = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_armMuscleCircumferencePercentil", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armMuscleCircumferencePercentil",
                schema: "nutrinfo");
        }
    }
}
