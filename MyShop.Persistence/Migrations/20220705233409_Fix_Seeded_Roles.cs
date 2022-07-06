using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Persistence.Migrations
{
    public partial class Fix_Seeded_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "991ad9e3-5c03-475c-abcf-3cb75633feb7", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "bbbb4542-d6ae-4107-a243-6df7cd2aa2d7", "CUSTOMER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "c3a90c58-a671-489f-b16d-c2c3132d2952", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "829fbb0c-0c2b-489e-9459-3ed18618be74", null });

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
        }
    }
}
