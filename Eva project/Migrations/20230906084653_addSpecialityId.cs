using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eva_project.Migrations
{
    /// <inheritdoc />
    public partial class addSpecialityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Courses");
        }
    }
}
