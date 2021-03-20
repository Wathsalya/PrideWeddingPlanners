using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegisterAPI.Migrations
{
    public partial class renameclienttabletoclients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientRegistrations",
                table: "ClientRegistrations");

            migrationBuilder.RenameTable(
                name: "ClientRegistrations",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "ClientRegistrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientRegistrations",
                table: "ClientRegistrations",
                column: "ID");
        }
    }
}
