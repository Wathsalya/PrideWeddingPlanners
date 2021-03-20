using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegisterAPI.Migrations
{
    public partial class Updatedsaloonvendormodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumber",
                table: "Saloons",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "Saloons");
        }
    }
}
