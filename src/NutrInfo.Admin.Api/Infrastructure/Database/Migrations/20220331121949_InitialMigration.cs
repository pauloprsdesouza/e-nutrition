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
                name: "user",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nutritionist",
                schema: "nutrinfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Crn = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritionist", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_nutritionist_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "nutrinfo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                schema: "nutrinfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_patient_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "nutrinfo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropTable(
                name: "user",
                schema: "nutrinfo");
        }
    }
}
