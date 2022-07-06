using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Persistence.Migrations
{
    internal partial class Seed_Test_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ea9c9eb-481d-4516-8c56-00e3554cc845", "f535c5c9-1d91-4055-8de6-2101e5d11ff9", "customer", null },
                    { "b2648a81-3b59-4086-8988-2f5feb250f69", "3e3cf467-1206-46b6-8456-d231e17c0f2f", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5c570d6a-b317-4249-983c-752d549969c5", 0, "2a92c6c2-eeae-45a1-89a0-18d529975f33", "Test Customer", "customer@myshop.com", true, false, null, "CUSTOMER@MYSHOP.COM", "CUSTOMER", "AQAAAAEAACcQAAAAENHp92V1bT/7wlgObrFfrD+DxTeAqjqfbzYTDXisERrVi1tQOKzN1herNbEnMgiDbw==", "+201234567891", true, "31b7f381-8a9e-4c0c-b6f4-de828740ebf7", false, "customer" },
                    { "90953a71-9566-477f-a134-28468412c276", 0, "61b608de-f923-47ee-b07d-dad139611b5a", "Test Admin", "admin@myshop.com", true, false, null, "ADMIN@MYSHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEP5MfnXcr32lQpERx6Y0J4uA9ciBDSSsFNdGQu55VD9gAGR8hxuaH8/4MEvOfFyniQ==", "+201234567890", true, "0fb92f16-9449-4493-a058-2ff7a7656cf5", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TVs" },
                    { 2, "Laptops" },
                    { 3, "Sound Systems" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6ea9c9eb-481d-4516-8c56-00e3554cc845", "5c570d6a-b317-4249-983c-752d549969c5" },
                    { "b2648a81-3b59-4086-8988-2f5feb250f69", "90953a71-9566-477f-a134-28468412c276" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Super AMOLED 4K Display", "LG Smart TV 50\"", 15000m },
                    { 2, 2, null, "Lenovo Thinkpad 15.6\" - 16 GB RAM", 22000m },
                    { 3, 2, null, "Dell Inspiron xyz", 18000m }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Percentage", "ProductId", "Quantity" },
                values: new object[] { 1, 0.30m, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ea9c9eb-481d-4516-8c56-00e3554cc845", "5c570d6a-b317-4249-983c-752d549969c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2648a81-3b59-4086-8988-2f5feb250f69", "90953a71-9566-477f-a134-28468412c276" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea9c9eb-481d-4516-8c56-00e3554cc845");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2648a81-3b59-4086-8988-2f5feb250f69");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c570d6a-b317-4249-983c-752d549969c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90953a71-9566-477f-a134-28468412c276");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");
        }
    }
}
