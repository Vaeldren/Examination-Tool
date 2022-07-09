using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalYearProject.Server.Data.Migrations
{
    public partial class actualfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "StudentExams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentExams");
        }
    }
}
