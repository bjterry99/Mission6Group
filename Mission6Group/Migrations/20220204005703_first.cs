using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6Group.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Quadrants",
                columns: table => new
                {
                    QuadrantID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuadrantName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrants", x => x.QuadrantID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    QuadrantID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Quadrants_QuadrantID",
                        column: x => x.QuadrantID,
                        principalTable: "Quadrants",
                        principalColumn: "QuadrantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 1, "Quadrant I: Important / Urgent" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 2, "Quadrant II: Important / Not Urgent" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 3, "Quadrant III: Not Important / Urgent" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantID", "QuadrantName" },
                values: new object[] { 4, "Quadrant IV: Not Important / Not Urgent" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "QuadrantID", "Task" },
                values: new object[] { 1, 2, false, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Finish mission 6" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryID",
                table: "Tasks",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_QuadrantID",
                table: "Tasks",
                column: "QuadrantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Quadrants");
        }
    }
}
