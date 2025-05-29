using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TasksApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MojTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskDescription = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    TaskStatus = table.Column<string>(type: "TEXT", nullable: false),
                    TaskDueDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MojTasks", x => x.TaskId);
                });

            migrationBuilder.InsertData(
                table: "MojTasks",
                columns: new[] { "TaskId", "TaskDescription", "TaskDueDate", "TaskStatus" },
                values: new object[,]
                {
                    { 1, "First Task", new DateOnly(2025, 5, 9), "Started" },
                    { 2, "Second Task", new DateOnly(2025, 4, 10), "Waiting" },
                    { 3, "Third Task", new DateOnly(2025, 3, 11), "Blocked" },
                    { 4, "Fourth Task", new DateOnly(2025, 2, 12), "Finished" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MojTasks");
        }
    }
}
