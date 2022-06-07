using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nutrinfo");

            migrationBuilder.CreateTable(
                name: "amputatedlimb",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Limb = table.Column<string>(type: "text", nullable: true),
                    Percentual = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                schema: "nutrinfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Neighborhood = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Complement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_address_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "nutrinfo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nutritionist",
                schema: "nutrinfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Crn = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Race = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "evaluation",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    NutritionistId = table.Column<int>(type: "integer", nullable: false),
                    BedNumber = table.Column<int>(type: "integer", nullable: true),
                    Protein = table.Column<double>(type: "double precision", nullable: true),
                    Energy = table.Column<double>(type: "double precision", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    Height = table.Column<double>(type: "double precision", nullable: true),
                    Imc = table.Column<double>(type: "double precision", nullable: true),
                    IsWalking = table.Column<bool>(type: "boolean", nullable: true),
                    HasEdema = table.Column<bool>(type: "boolean", nullable: true),
                    HasAscite = table.Column<bool>(type: "boolean", nullable: true),
                    HasAmputatedLimb = table.Column<bool>(type: "boolean", nullable: true),
                    NutritionState = table.Column<int>(type: "integer", nullable: true),
                    DiseaseSeverity = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evaluation_nutritionist_NutritionistId",
                        column: x => x.NutritionistId,
                        principalSchema: "nutrinfo",
                        principalTable: "nutritionist",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_evaluation_patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "nutrinfo",
                        principalTable: "patient",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "amputatedlimbs",
                schema: "nutrinfo",
                columns: table => new
                {
                    AmputatedLimbsId = table.Column<int>(type: "integer", nullable: false),
                    EvaluationsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimbs", x => new { x.AmputatedLimbsId, x.EvaluationsId });
                    table.ForeignKey(
                        name: "FK_amputatedlimbs_amputatedlimb_AmputatedLimbsId",
                        column: x => x.AmputatedLimbsId,
                        principalSchema: "nutrinfo",
                        principalTable: "amputatedlimb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_amputatedlimbs_evaluation_EvaluationsId",
                        column: x => x.EvaluationsId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimbs_EvaluationsId",
                schema: "nutrinfo",
                table: "amputatedlimbs",
                column: "EvaluationsId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluation_NutritionistId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "NutritionistId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluation_PatientId",
                schema: "nutrinfo",
                table: "evaluation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_nutritionist_Crn",
                schema: "nutrinfo",
                table: "nutritionist",
                column: "Crn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Cpf",
                schema: "nutrinfo",
                table: "user",
                column: "Cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "amputatedlimbs",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "amputatedlimb",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "evaluation",
                schema: "nutrinfo");

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
