using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class AddRoleEntityToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4683ba8d-7685-4e37-bcfb-96ff9c21cbb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "528839bf-dabe-4b02-bc40-0b15f102d62c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab07dfb-87ef-4b93-bd7f-9be89c80f8cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e67b4ab6-742f-4671-99bd-eaca0e834ef0", "17f22d7e-5fb4-41a9-9245-830e7c869f47", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2bad337-6631-4e25-b09c-2db53d875226", "fc8199bd-519b-426f-8c4d-8722f6734cc7", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "565cd42d-c2cb-4cf0-b759-941a2e86aa89", "45c7aaa5-5f79-49c7-9cd6-fef5049700e3", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "565cd42d-c2cb-4cf0-b759-941a2e86aa89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2bad337-6631-4e25-b09c-2db53d875226");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e67b4ab6-742f-4671-99bd-eaca0e834ef0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4683ba8d-7685-4e37-bcfb-96ff9c21cbb4", "492f5f7d-089e-4823-bf16-879dcf550ab6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "528839bf-dabe-4b02-bc40-0b15f102d62c", "a3a5bbda-d1f7-445f-a774-c491bf15b7dd", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab07dfb-87ef-4b93-bd7f-9be89c80f8cf", "0bc72f97-b4ed-4674-9b43-1a601fe75731", "User", "USER" });
        }
    }
}
