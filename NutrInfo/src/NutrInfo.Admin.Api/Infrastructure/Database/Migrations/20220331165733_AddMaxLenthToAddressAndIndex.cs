using Microsoft.EntityFrameworkCore.Migrations;

namespace NutrInfo.Admin.Api.Migrations
{
    public partial class AddMaxLenthToAddressAndIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "nutrinfo",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "address",
                schema: "nutrinfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(maxLength: 200, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 100, nullable: false),
                    Complement = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_user_Cpf",
                schema: "nutrinfo",
                table: "user",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nutritionist_Crn",
                schema: "nutrinfo",
                table: "nutritionist",
                column: "Crn",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address",
                schema: "nutrinfo");

            migrationBuilder.DropIndex(
                name: "IX_user_Cpf",
                schema: "nutrinfo",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_nutritionist_Crn",
                schema: "nutrinfo",
                table: "nutritionist");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "nutrinfo",
                table: "user",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
