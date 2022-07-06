using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Persistence.Migrations
{
    public partial class Make_Order_CustomerId_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b",
                column: "ConcurrencyStamp",
                value: "c3a90c58-a671-489f-b16d-c2c3132d2952");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6",
                column: "ConcurrencyStamp",
                value: "829fbb0c-0c2b-489e-9459-3ed18618be74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81863fe1-13c9-4936-93ad-545f06491044", "AQAAAAEAACcQAAAAEPvF7tsokRQYupH8vIJEzQKfxWa2p3RI0I0so4v0Zg+20HdoVCF35QEAwlfnCpbLlw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce07ec9b-df25-4bf9-b82e-258547f5829a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3da8e521-c41f-4891-8884-f1e786ea29b5", "AQAAAAEAACcQAAAAEIr1jkeRRWcUNXl9qSbHLKAwf1zWpQVQf3kA4xtlzbNFb88tw5U/Wpbd5IcI82Icnw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b",
                column: "ConcurrencyStamp",
                value: "8bf9be50-3a42-49f1-9c01-1440b8527993");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6",
                column: "ConcurrencyStamp",
                value: "5389308c-dd90-4c9c-bbea-699f8c4f2207");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8fa0c61-4744-4506-9f88-d7279fa39f8f", "AQAAAAEAACcQAAAAEKP7C/DAxzqswQ3j84EWMUglULPM/CoWbGqj2bn/HiGQygIwQQaAo1pe/OzvyHfQmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce07ec9b-df25-4bf9-b82e-258547f5829a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff252907-4bb8-4929-9584-005d87e4f140", "AQAAAAEAACcQAAAAEAdIEHRN4PoeXJJ9RTqL9/XSQjyRWinfOcy21zr8PYU6shGjQqyRALZ5xKSMIObLww==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
