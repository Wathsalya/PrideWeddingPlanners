using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegisterAPI.Migrations
{
    public partial class newlyupadted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Located_province",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Max_package",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Min_package",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Located_province",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Max_package",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Min_package",
                table: "Employees");
        }
    }
}
