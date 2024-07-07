using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvasEnem.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PDF = table.Column<byte[]>(type: "IMAGE", nullable: false),
                    ColorNotebook = table.Column<string>(name: "Color Notebook", type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    ExamDate = table.Column<DateTime>(name: "Exam Date", type: "DATETIME2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
