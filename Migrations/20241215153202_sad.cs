using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class sad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "", "HP Zbook Power G9", 19.99m, 50 },
                    { 2, 2, 2, "Imgs/p7", "HP Zbook Power G9 ", 29.99m, 30 },
                    { 3, 3, 3, "Imgs/p6", "HP Zbook Power G9", 39.99m, 20 },
                    { 4, 4, 4, "Imgs/p5", "HP Zbook Power G9", 49.99m, 60 },
                    { 5, 5, 5, "Imgs/p4", "HP Zbook Power G9", 59.99m, 40 },
                    { 6, 6, 6, "Imgs/p3", "HP Zbook Power G9", 69.99m, 25 },
                    { 7, 7, 7, "Imgs/p2", "HP Zbook Power G9", 79.99m, 35 },
                    { 8, 8, 8, "Imgs/p3", "HP Zbook Power G9", 89.99m, 15 },
                    { 9, 9, 9, "Imgs/p4", "HP Zbook Power G9", 99.99m, 10 },
                    { 10, 10, 10, "Imgs/p5", "HP Zbook Power G9", 109.99m, 5 },
                    { 11, 11, 11, "Imgs/p10", "HP Zbook Power G9", 119.99m, 12 },
                    { 12, 12, 12, "Imgs/p7", "HP Zbook Power G9", 129.99m, 18 },
                    { 13, 13, 13, "Imgs/p9", "HP Zbook Power G9", 139.99m, 22 },
                    { 14, 14, 14, "Imgs/p8", "HP Zbook Power G9", 149.99m, 8 },
                    { 15, 15, 15, "Imgs/p10", "HP Zbook Power G9", 159.99m, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);
        }
    }
}
