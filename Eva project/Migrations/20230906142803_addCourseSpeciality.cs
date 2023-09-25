using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eva_project.Migrations
{
    /// <inheritdoc />
    public partial class addCourseSpeciality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "EstimatedTime",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimatedTime",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
