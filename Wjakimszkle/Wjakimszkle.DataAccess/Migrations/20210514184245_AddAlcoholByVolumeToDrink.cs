using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class AddAlcoholByVolumeToDrink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AlcoholByVolume",
                table: "Drinks",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlcoholByVolume",
                table: "Drinks");
        }
    }
}
