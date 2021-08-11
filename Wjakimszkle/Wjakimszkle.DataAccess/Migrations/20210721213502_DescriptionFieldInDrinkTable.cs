using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class DescriptionFieldInDrinkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Drinks");
        }
    }
}
