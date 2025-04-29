using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class initOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LowStockThreshold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "LowStockThreshold", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Description A", 10, "Product A", 10.99m, 100 },
                    { 2, "Description B", 15, "Product B", 15.49m, 150 },
                    { 3, "Description C", 20, "Product C", 8.99m, 200 },
                    { 4, "Description D", 8, "Product D", 12.99m, 80 },
                    { 5, "Description E", 12, "Product E", 5.99m, 120 },
                    { 6, "Description F", 25, "Product F", 20.00m, 300 },
                    { 7, "Description G", 5, "Product G", 7.50m, 50 },
                    { 8, "Description H", 6, "Product H", 11.25m, 60 },
                    { 9, "Description I", 9, "Product I", 9.95m, 90 },
                    { 10, "Description J", 7, "Product J", 14.75m, 70 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
