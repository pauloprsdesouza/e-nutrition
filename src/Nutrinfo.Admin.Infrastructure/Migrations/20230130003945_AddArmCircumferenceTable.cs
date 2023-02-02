using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddArmCircumferenceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "armCircumferencePercentil",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartAge = table.Column<int>(type: "integer", nullable: false),
                    EndAge = table.Column<int>(type: "integer", nullable: false),
                    P5 = table.Column<decimal>(type: "numeric", nullable: false),
                    P10 = table.Column<decimal>(type: "numeric", nullable: false),
                    P15 = table.Column<decimal>(type: "numeric", nullable: false),
                    P25 = table.Column<decimal>(type: "numeric", nullable: false),
                    P50 = table.Column<decimal>(type: "numeric", nullable: false),
                    P75 = table.Column<decimal>(type: "numeric", nullable: false),
                    P85 = table.Column<decimal>(type: "numeric", nullable: false),
                    P90 = table.Column<decimal>(type: "numeric", nullable: false),
                    P95 = table.Column<decimal>(type: "numeric", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_armCircumferencePercentil", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armCircumferencePercentil",
                schema: "nutrinfo");
        }
    }
}
