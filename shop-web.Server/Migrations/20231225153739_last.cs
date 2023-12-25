using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shop_web.Server.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, "Смартфон от компании Apple, 128 GB памяти. Цвет черный.", "iPhone 14", 999m },
                    { 2, 5, "Смартфон от компании Apple, 512 GB памяти. Цвет серый.", "iPhone 14 Pro", 1099m },
                    { 3, 5, "Ноубук от компании Apple, 1 TB памяти. Цвет серебристый.", "MacBook Pro 2022", 1399m },
                    { 4, 5, "Компьютер от компании Apple, 512 GB памяти. Цвет серебристый.", "Mac Mini", 699m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[] { 10, 5, "Смартфон от компании Apple", "iPhone 14", 50m });
        }
    }
}
