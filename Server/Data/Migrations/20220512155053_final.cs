using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalYearProject.Server.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student",
                table: "Answers",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Answers",
                newName: "Student");
        }
    }
}
