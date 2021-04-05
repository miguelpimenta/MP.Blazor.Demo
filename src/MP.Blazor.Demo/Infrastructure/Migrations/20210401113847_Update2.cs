using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP.Blazor.Demo.Infrastructure.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WetherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"), new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Sweltering", -9 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WetherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"), new DateTime(2021, 3, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), "Balmy", -20 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WetherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"), new DateTime(2021, 3, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "Scorching", -18 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WetherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("810a8c8b-6379-42a9-a223-5f41dff28769"), new DateTime(2021, 3, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "Bracing", 34 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WetherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("11063071-7eba-401e-83c7-f411776eada5"), new DateTime(2021, 3, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Freezing", -12 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "WetherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("11063071-7eba-401e-83c7-f411776eada5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "WetherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "WetherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("810a8c8b-6379-42a9-a223-5f41dff28769"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "WetherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "WetherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"));
        }
    }
}
