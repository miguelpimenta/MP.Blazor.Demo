using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP.Blazor.Demo.Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WetherForecasts",
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
                    table.PrimaryKey("PK_WetherForecasts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11063071-7eba-401e-83c7-f411776eada5"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { "B159XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), "...", "...", 1m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { "A123XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), "Something Good", "...", 10m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810a8c8b-6379-42a9-a223-5f41dff28769"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { "B159XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), "...", "...", 1m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { "A789XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), "Something Cheap", "...", 1m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { "A456XYZ", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), "Something Expensive", "...", 155.5m, new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WetherForecasts",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11063071-7eba-401e-83c7-f411776eada5"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810a8c8b-6379-42a9-a223-5f41dff28769"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0L });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"),
                columns: new[] { "Code", "CreatedAt", "CreatedBy", "Description", "Observations", "Price", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0L });
        }
    }
}
