using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class AddGenreToDrinkType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "DrinkTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "DrinkTypes");
        }
    }
}
