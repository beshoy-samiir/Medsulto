using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eva_project.Migrations
{
    /// <inheritdoc />
    public partial class abc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseOutline",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDoctorsAttended",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetAudience",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CourseOutline", "NumberOfDoctorsAttended", "Ratings", "TargetAudience" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CourseOutline", "NumberOfDoctorsAttended", "Ratings", "TargetAudience" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CourseOutline", "NumberOfDoctorsAttended", "Ratings", "TargetAudience" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseOutline",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NumberOfDoctorsAttended",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TargetAudience",
                table: "Courses");
        }
    }
}
