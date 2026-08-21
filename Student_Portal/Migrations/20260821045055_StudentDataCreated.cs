using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Portal.Migrations
{
    /// <inheritdoc />
    public partial class StudentDataCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentMasters",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentMasters", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_studentMasters_courseMasters_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courseMasters",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Restrict
                    );

                    table.ForeignKey(
                        name: "FK_studentMasters_departmentMasters_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "departmentMasters",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentMasters_CourseID",
                table: "studentMasters",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_studentMasters_DepartmentID",
                table: "studentMasters",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentMasters");
        }
    }
}
