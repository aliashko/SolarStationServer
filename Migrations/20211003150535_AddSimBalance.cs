using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarStationServer.Migrations
{
    public partial class AddSimBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SimMoneyBalance",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SimMoneyBalance",
                table: "Reports");
        }
    }
}
