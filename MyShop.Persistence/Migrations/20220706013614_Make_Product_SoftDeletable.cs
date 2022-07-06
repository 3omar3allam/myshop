using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Persistence.Migrations
{
    public partial class Make_Product_SoftDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b",
                column: "ConcurrencyStamp",
                value: "975ececd-d3e1-4cdc-8f03-f7897a97ada9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6",
                column: "ConcurrencyStamp",
                value: "edb3d2d4-c079-4097-9c2a-51b8871e72f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b089cc16-71ba-4434-b064-9b6bfbd7a6e6", "AQAAAAEAACcQAAAAEKRQkmTdXirdAjsn4eFBZoGbH+lZqTxuiDW9+Jz7yPfBtHudZvLJoHk00cHLLO4XzQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce07ec9b-df25-4bf9-b82e-258547f5829a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e97cb7d3-99fa-46c6-9c53-b15bfe6dc12e", "AQAAAAEAACcQAAAAEGBnMqmcjWBMe9nZOG2Iu9y7s768THQ2h7BXeRDRfeda+G3DewvrsI7y/OWFYvYryQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b",
                column: "ConcurrencyStamp",
                value: "991ad9e3-5c03-475c-abcf-3cb75633feb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6",
                column: "ConcurrencyStamp",
                value: "bbbb4542-d6ae-4107-a243-6df7cd2aa2d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65d64b3d-3e42-4ca4-be7c-8695d4eb7259", "AQAAAAEAACcQAAAAEI9pE3JQYNX210Dd5jrKiCwVYeHUhuU+3ZhYDTVDlAw55P1I4DplgtTmmuWOmQVCDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce07ec9b-df25-4bf9-b82e-258547f5829a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34a1244d-e800-403c-8b7a-586ae59dfb12", "AQAAAAEAACcQAAAAECpLx7KXzWKvgANX4SwnB82Hbb4FuRbx9JjShOoS9M7n/JZCBARKqLoF1XlVvIMmcQ==" });
        }
    }
}
