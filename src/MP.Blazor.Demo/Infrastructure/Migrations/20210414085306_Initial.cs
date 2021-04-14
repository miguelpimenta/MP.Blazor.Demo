using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP.Blazor.Demo.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Observations = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    Version = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TemperatureC = table.Column<int>(type: "INTEGER", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"), true, "A123XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "Something Good", "...", 10m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"), true, "A456XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "Something Expensive", "...", 155.5m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"), true, "A789XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "Something Cheap", "...", 1m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("810a8c8b-6379-42a9-a223-5f41dff28769"), true, "B159XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "...", "...", 1m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("11063071-7eba-401e-83c7-f411776eada5"), true, "B159XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "...", "...", 1m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"), new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Sweltering", -9 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"), new DateTime(2021, 3, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), "Balmy", -20 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"), new DateTime(2021, 3, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "Scorching", -18 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("810a8c8b-6379-42a9-a223-5f41dff28769"), new DateTime(2021, 3, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "Bracing", 34 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("11063071-7eba-401e-83c7-f411776eada5"), new DateTime(2021, 3, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Freezing", -12 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WeatherForecasts",
                schema: "dbo");
        }
    }
}
