using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalYearProject.Server.Data.Migrations
{
    public partial class finalmigrationentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "StudentExams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "StudentExams");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Answers");
        }
    }
}
