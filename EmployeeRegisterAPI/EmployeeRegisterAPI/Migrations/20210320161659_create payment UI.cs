using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegisterAPI.Migrations
{
    public partial class createpaymentUI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNo = table.Column<string>(nullable: true),
                    CardholderName = table.Column<string>(nullable: true),
                    ExpDate = table.Column<string>(nullable: true),
                    CVV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
