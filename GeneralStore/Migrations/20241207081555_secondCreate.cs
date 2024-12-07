using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneralStore.Migrations
{
    public partial class secondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM `Items`;");
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Category", "DateListed", "Description", "InStock", "Name", "OrderId", "Price", "StockQuantity", "Weight" },
                values: new object[,]
                {
                    { 1, "Furniture", new DateTime(2024, 12, 7, 0, 15, 55, 590, DateTimeKind.Local).AddTicks(5561), "A nice hardwood desk", true, "Hardwood Desk", null, 150.00m, 10, 0.0m },
                    { 2, "Furniture", new DateTime(2024, 12, 7, 0, 15, 55, 590, DateTimeKind.Local).AddTicks(5565), "Chair made of wood.", true, "Hardwood Chair", null, 20.00m, 10, 0.0m },
                    { 3, "Lighting", new DateTime(2024, 12, 7, 0, 15, 55, 590, DateTimeKind.Local).AddTicks(5569), "Lamp Of Steel", true, "Steel Lamp", null, 100.00m, 10, 0.0m },
                    { 4, "Tools", new DateTime(2024, 12, 7, 0, 15, 55, 590, DateTimeKind.Local).AddTicks(5573), "Basic Power Drill", true, "Power Drill", null, 150.00m, 10, 0.0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);
        }
    }
}
