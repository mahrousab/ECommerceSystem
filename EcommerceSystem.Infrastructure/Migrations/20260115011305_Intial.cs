using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Computers" },
                    { 3, "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PasswordHash", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@email.com", "Ahmed Ali", "hashed123", "0100000000" },
                    { 2, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@email.com", "Sara Mohamed", "hashed456", "0111111111" },
                    { 3, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar@email.com", "Omar Hassan", "hashed789", "0122222222" },
                    { 4, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "laila@email.com", "Laila Youssef", "hashed321", "0133333333" },
                    { 5, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahrousellithy99@gmail.com", "mahrous Ellithy", "mahroushed321", "01027782815" },
                    { 6, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HazemFarag@mail.com", "Hazem Farag", "hashed654", "0144444444" },
                    { 7, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tofaha@gmail.com", "mahmoud tofaha", "hashed987", "0155555555" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "UserId" },
                values: new object[,]
                {
                    { 1, "Cairo", "Egypt", "11765", "Nasr City", 1 },
                    { 2, "shipin Elqanter", "Qalyopia", "13713", "Hussin Roshdy", 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "Status", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paid", 4000m, 1 },
                    { 2, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not Paid", 41300m, 2 },
                    { 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not Paid", 45300m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Latest Apple iPhone", "iPhone 12", 45000m, 10 },
                    { 2, 1, "55 inch 4K TV", "Samsung Smart TV", 30000m, 5 },
                    { 3, 1, "Latest Apple iPhone", "iPhone 14", 45000m, 10 },
                    { 4, 2, "High-performance laptop", "Dell XPS 13", 60000m, 7 },
                    { 5, 3, "Noise-cancelling headphones", "Sony WH-1000XM4", 20000m, 15 },
                    { 6, 2, "Powerful laptop for professionals", "Apple MacBook Pro", 120000m, 4 },
                    { 7, 1, "Google's flagship smartphone", "Google Pixel 6", 40000m, 8 },
                    { 8, 3, "Wireless Bluetooth Headphones", "Bose QuietComfort 35 II", 18000m, 12 },
                    { 9, 2, "Convertible laptop with touch screen", "HP Spectre x360", 75000m, 6 },
                    { 10, 1, "High-end smartphone with fast performance", "OnePlus 9 Pro", 50000m, 9 },
                    { 11, 1, "65 inch OLED 4K TV", "LG OLED TV", 80000m, 3 },
                    { 12, 2, "Gaming laptop with powerful GPU", "Asus ROG Zephyrus G14", 95000m, 5 },
                    { 13, 3, "Portable Bluetooth Speaker", "JBL Flip 5", 7000m, 20 },
                    { 14, 2, "Sleek laptop with touchscreen", "Microsoft Surface Laptop 4", 85000m, 4 },
                    { 15, 1, "Premium smartphone with advanced camera", "Sony Xperia 1 III", 60000m, 7 },
                    { 16, 3, "On-ear noise cancelling headphones", "Beats Solo Pro", 15000m, 10 },
                    { 17, 2, "Business laptop with robust features", "Lenovo ThinkPad X1 Carbon", 110000m, 11 },
                    { 18, 2, "Cotton T-Shirt", "T-Shirt", 300m, 50 },
                    { 19, 2, "Denim Jeans", "Jeans", 1200m, 40 },
                    { 20, 2, "Running Sneakers", "Sneakers", 2500m, 30 },
                    { 21, 2, "Leather Jacket", "Jacket", 5000m, 20 },
                    { 22, 2, "Baseball Cap", "Hat", 800m, 60 },
                    { 23, 2, "Polarized Sunglasses", "Sunglasses", 1500m, 25 },
                    { 24, 2, "Digital Watch", "Watch", 3000m, 15 },
                    { 25, 2, "Leather Belt", "Belt", 700m, 35 },
                    { 26, 2, "Wool Scarf", "Scarf", 600m, 45 },
                    { 27, 2, "Winter Gloves", "Gloves", 400m, 55 },
                    { 28, 2, "Cotton Socks", "Socks", 200m, 70 },
                    { 29, 2, "Evening Dress", "Dress", 4000m, 18 },
                    { 30, 2, "Denim Skirt", "Skirt", 1500m, 22 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 45000m, 1, 1 },
                    { 2, 2, 42000m, 2, 2 },
                    { 3, 3, 42030m, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "OrderId", "PaidAt", "PaymentMethod", "PaymentStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Card", "Completed" },
                    { 2, 2, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vodafon Cash", "Completed" },
                    { 3, 3, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange Cash", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://example.com/images/iphone12-front.jpg", 1 },
                    { 2, "https://example.com/images/iphone12-back.jpg", 1 },
                    { 3, "https://example.com/images/samsung-tv.jpg", 2 },
                    { 4, "https://example.com/images/iphone14-front.jpg", 3 },
                    { 5, "https://example.com/images/iphone14-back.jpg", 3 },
                    { 6, "https://example.com/images/dell-xps13.jpg", 4 },
                    { 7, "https://example.com/images/sony-headphones.jpg", 5 },
                    { 8, "https://example.com/images/apple-watch.jpg", 6 },
                    { 9, "https://example.com/images/google-pixel6-front.jpg", 7 },
                    { 10, "https://example.com/images/google-pixel6-back.jpg", 7 },
                    { 11, "https://example.com/images/lg-refrigerator.jpg", 8 },
                    { 12, "https://example.com/images/amazon-echo.jpg", 9 },
                    { 13, "https://example.com/images/nintendo-switch.jpg", 10 },
                    { 14, "https://example.com/images/fitbit-charge5.jpg", 11 },
                    { 15, "https://example.com/images/sony-playstation5.jpg", 12 },
                    { 16, "https://example.com/images/microsoft-surface-pro.jpg", 13 },
                    { 17, "https://example.com/images/canon-eos-r5.jpg", 14 },
                    { 18, "https://example.com/images/bose-quietcomfort35.jpg", 15 },
                    { 19, "https://example.com/images/jbl-flip5.jpg", 16 },
                    { 20, "https://example.com/images/anker-powercore-10000.jpg", 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
