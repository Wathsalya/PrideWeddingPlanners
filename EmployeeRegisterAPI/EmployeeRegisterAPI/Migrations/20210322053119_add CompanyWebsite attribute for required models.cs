using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegisterAPI.Migrations
{
    public partial class addCompanyWebsiteattributeforrequiredmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Saloons");

            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Jwellers");

            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Entertainers");

            migrationBuilder.DropColumn(
                name: "Mid_package",
                table: "Decorators");

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Saloons",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Photographers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Jwellers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Hotels",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Entertainers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Decorators",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Saloons");

            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Jwellers");

            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Entertainers");

            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Decorators");

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Saloons",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Photographers",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Jwellers",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Hotels",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Entertainers",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mid_package",
                table: "Decorators",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
