using Microsoft.EntityFrameworkCore.Migrations;

namespace MP.Blazor.Demo.Infrastructure.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WetherForecasts",
                schema: "dbo",
                table: "WetherForecasts");

            migrationBuilder.RenameTable(
                name: "WetherForecasts",
                schema: "dbo",
                newName: "WeatherForecasts",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherForecasts",
                schema: "dbo",
                table: "WeatherForecasts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherForecasts",
                schema: "dbo",
                table: "WeatherForecasts");

            migrationBuilder.RenameTable(
                name: "WeatherForecasts",
                schema: "dbo",
                newName: "WetherForecasts",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WetherForecasts",
                schema: "dbo",
                table: "WetherForecasts",
                column: "Id");
        }
    }
}
