using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class AddedServingTemperatureFieldToDrinkTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "565cd42d-c2cb-4cf0-b759-941a2e86aa89");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "c2bad337-6631-4e25-b09c-2db53d875226");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "e67b4ab6-742f-4671-99bd-eaca0e834ef0");

            migrationBuilder.AddColumn<int>(
                name: "ServingTemperature",
                table: "DrinkTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServingTemperature",
                table: "DrinkTypes");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "e67b4ab6-742f-4671-99bd-eaca0e834ef0", "17f22d7e-5fb4-41a9-9245-830e7c869f47", "Admin", "ADMIN" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "c2bad337-6631-4e25-b09c-2db53d875226", "fc8199bd-519b-426f-8c4d-8722f6734cc7", "Editor", "EDITOR" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "565cd42d-c2cb-4cf0-b759-941a2e86aa89", "45c7aaa5-5f79-49c7-9cd6-fef5049700e3", "User", "USER" });
        }
    }
}
