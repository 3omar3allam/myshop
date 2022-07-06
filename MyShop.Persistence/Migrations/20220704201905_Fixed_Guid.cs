using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Persistence.Migrations
{
    public partial class Fixed_Guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ea9c9eb-481d-4516-8c56-00e3554cc845", "5c570d6a-b317-4249-983c-752d549969c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2648a81-3b59-4086-8988-2f5feb250f69", "90953a71-9566-477f-a134-28468412c276" });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8da53e6-9be6-4a54-9c39-4941fedd295b", "8bf9be50-3a42-49f1-9c01-1440b8527993", "admin", null },
                    { "e360802c-872c-4026-b374-daae939884a6", "5389308c-dd90-4c9c-bbea-699f8c4f2207", "customer", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a", 0, "a8fa0c61-4744-4506-9f88-d7279fa39f8f", "Test Admin", "admin@myshop.com", true, false, null, "ADMIN@MYSHOP.COM", "ADMIN", "AQAAAAEAACcQAAAAEKP7C/DAxzqswQ3j84EWMUglULPM/CoWbGqj2bn/HiGQygIwQQaAo1pe/OzvyHfQmQ==", "+201234567890", true, "f46db2be-8e5c-47d2-bd85-399ed98c8be2", false, "admin" },
                    { "ce07ec9b-df25-4bf9-b82e-258547f5829a", 0, "ff252907-4bb8-4929-9584-005d87e4f140", "Test Customer", "customer@myshop.com", true, false, null, "CUSTOMER@MYSHOP.COM", "CUSTOMER", "AQAAAAEAACcQAAAAEAdIEHRN4PoeXJJ9RTqL9/XSQjyRWinfOcy21zr8PYU6shGjQqyRALZ5xKSMIObLww==", "+201234567891", true, "3ec2a34d-44eb-428d-9b79-dc87394e121a", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d8da53e6-9be6-4a54-9c39-4941fedd295b", "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e360802c-872c-4026-b374-daae939884a6", "ce07ec9b-df25-4bf9-b82e-258547f5829a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8da53e6-9be6-4a54-9c39-4941fedd295b", "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e360802c-872c-4026-b374-daae939884a6", "ce07ec9b-df25-4bf9-b82e-258547f5829a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8da53e6-9be6-4a54-9c39-4941fedd295b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360802c-872c-4026-b374-daae939884a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce07ec9b-df25-4bf9-b82e-258547f5829a");

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ea9c9eb-481d-4516-8c56-00e3554cc845", "5c570d6a-b317-4249-983c-752d549969c5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b2648a81-3b59-4086-8988-2f5feb250f69", "90953a71-9566-477f-a134-28468412c276" });
        }
    }
}
