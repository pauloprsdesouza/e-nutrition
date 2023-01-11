using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrinfo.Admin.Infrastructure.Migrations
{
    public partial class AddNextEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextEvaluation",
                schema: "nutrinfo",
                table: "evaluation",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextEvaluation",
                schema: "nutrinfo",
                table: "evaluation");
        }
    }
}
