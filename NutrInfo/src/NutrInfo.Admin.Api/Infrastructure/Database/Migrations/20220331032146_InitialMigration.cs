using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nutrinfo");

            migrationBuilder.CreateTable(
                name: "nutritionist",
                schema: "nutrinfo",
                columns: table => new
                {
                    Crn = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritionist", x => x.Crn);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutritionist",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "patient",
                schema: "nutrinfo");
        }
    }
}
