using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nutrinfo");

            migrationBuilder.CreateTable(
                name: "amputatedlimbpercentage",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Percentage = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimbpercentage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsciteDegree",
                schema: "nutrinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Degree = table.Column<int>(type: "integer", nullable: false),
                    AsciticWeight = table.Column<double>(type: "double precision", nullable: false),
                    PeripheralEdema = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsciteDegree", x => x.Id);
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
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Imc = table.Column<double>(type: "double precision", nullable: false),
                    IsWalking = table.Column<bool>(type: "boolean", nullable: false),
                    EdemaWeight = table.Column<double>(type: "double precision", nullable: false),
                    AsciteWeight = table.Column<double>(type: "double precision", nullable: false),
                    NutritionalState = table.Column<string>(type: "text", nullable: false),
                    DiseaseSeverity = table.Column<string>(type: "text", nullable: false),
                    LostWeightLastThreeMonths = table.Column<double>(type: "double precision", nullable: false),
                    ReducedDietaryIntake = table.Column<bool>(type: "boolean", nullable: false),
                    SeriouslyIllPatient = table.Column<bool>(type: "boolean", nullable: false),
                    ArmCircumference = table.Column<double>(type: "double precision", nullable: false),
                    TricepsPleat = table.Column<double>(type: "double precision", nullable: false),
                    CalfCircumference = table.Column<double>(type: "double precision", nullable: false),
                    ArmMuscleCircumference = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Step = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "amputatedlimb",
                schema: "nutrinfo",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AmputatedLimbPercentageId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amputatedlimb", x => new { x.EvaluationId, x.PatientId, x.AmputatedLimbPercentageId });
                    table.ForeignKey(
                        name: "FK_amputatedlimb_amputatedlimbpercentage_AmputatedLimbPercenta~",
                        column: x => x.AmputatedLimbPercentageId,
                        principalSchema: "nutrinfo",
                        principalTable: "amputatedlimbpercentage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_amputatedlimb_evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_amputatedlimb_patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "nutrinfo",
                        principalTable: "patient",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsciteDegreeEvaluation",
                schema: "nutrinfo",
                columns: table => new
                {
                    AscitesId = table.Column<int>(type: "integer", nullable: false),
                    EvaluationsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsciteDegreeEvaluation", x => new { x.AscitesId, x.EvaluationsId });
                    table.ForeignKey(
                        name: "FK_AsciteDegreeEvaluation_AsciteDegree_AscitesId",
                        column: x => x.AscitesId,
                        principalSchema: "nutrinfo",
                        principalTable: "AsciteDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsciteDegreeEvaluation_evaluation_EvaluationsId",
                        column: x => x.EvaluationsId,
                        principalSchema: "nutrinfo",
                        principalTable: "evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimb_AmputatedLimbPercentageId",
                schema: "nutrinfo",
                table: "amputatedlimb",
                column: "AmputatedLimbPercentageId");

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimb_PatientId",
                schema: "nutrinfo",
                table: "amputatedlimb",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_amputatedlimb_Reason",
                schema: "nutrinfo",
                table: "amputatedlimb",
                column: "Reason");

            migrationBuilder.CreateIndex(
                name: "IX_AsciteDegreeEvaluation_EvaluationsId",
                schema: "nutrinfo",
                table: "AsciteDegreeEvaluation",
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
                name: "amputatedlimb",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "AsciteDegreeEvaluation",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "amputatedlimbpercentage",
                schema: "nutrinfo");

            migrationBuilder.DropTable(
                name: "AsciteDegree",
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
