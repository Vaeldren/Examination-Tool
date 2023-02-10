using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalYearProject.Server.Data.Migrations
{
    public partial class finalfinalentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Answers",
                newName: "StudentExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentExamId",
                table: "Answers",
                newName: "StudentId");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
