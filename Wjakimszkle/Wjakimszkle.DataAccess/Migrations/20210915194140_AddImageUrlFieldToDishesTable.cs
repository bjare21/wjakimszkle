using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class AddImageUrlFieldToDishesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dishes");
        }
    }
}
