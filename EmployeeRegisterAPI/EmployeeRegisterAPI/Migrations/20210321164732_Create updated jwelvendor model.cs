using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegisterAPI.Migrations
{
    public partial class Createupdatedjwelvendormodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jweellers",
                table: "Jweellers");

            migrationBuilder.RenameTable(
                name: "Jweellers",
                newName: "Jwellers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jwellers",
                table: "Jwellers",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jwellers",
                table: "Jwellers");

            migrationBuilder.RenameTable(
                name: "Jwellers",
                newName: "Jweellers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jweellers",
                table: "Jweellers",
                column: "EmployeeID");
        }
    }
}
