using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarStationServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RaindropLevel = table.Column<int>(type: "int", nullable: false),
                    SoilMoistureLevel = table.Column<int>(type: "int", nullable: false),
                    GsmSignalLevel = table.Column<int>(type: "int", nullable: false),
                    SolarVoltage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SolarCurrent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatteryVoltage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArduinoVoltage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GsmVoltage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerMode = table.Column<int>(type: "int", nullable: false),
                    RestartsCount = table.Column<long>(type: "bigint", nullable: false),
                    GsmErrors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
