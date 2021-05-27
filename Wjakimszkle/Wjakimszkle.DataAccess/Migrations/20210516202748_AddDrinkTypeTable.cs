using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class AddDrinkTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkTypeId",
                table: "Drinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DrinkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishDrinkType",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    DrinkTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishDrinkType", x => new { x.DishesId, x.DrinkTypesId });
                    table.ForeignKey(
                        name: "FK_DishDrinkType_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishDrinkType_DrinkTypes_DrinkTypesId",
                        column: x => x.DrinkTypesId,
                        principalTable: "DrinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkTypeGlass",
                columns: table => new
                {
                    DrinkTypesId = table.Column<int>(type: "int", nullable: false),
                    GlassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkTypeGlass", x => new { x.DrinkTypesId, x.GlassesId });
                    table.ForeignKey(
                        name: "FK_DrinkTypeGlass_DrinkTypes_DrinkTypesId",
                        column: x => x.DrinkTypesId,
                        principalTable: "DrinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkTypeGlass_Glasses_GlassesId",
                        column: x => x.GlassesId,
                        principalTable: "Glasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DrinkTypeId",
                table: "Drinks",
                column: "DrinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DishDrinkType_DrinkTypesId",
                table: "DishDrinkType",
                column: "DrinkTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkTypeGlass_GlassesId",
                table: "DrinkTypeGlass",
                column: "GlassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_DrinkTypes_DrinkTypeId",
                table: "Drinks",
                column: "DrinkTypeId",
                principalTable: "DrinkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_DrinkTypes_DrinkTypeId",
                table: "Drinks");

            migrationBuilder.DropTable(
                name: "DishDrinkType");

            migrationBuilder.DropTable(
                name: "DrinkTypeGlass");

            migrationBuilder.DropTable(
                name: "DrinkTypes");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_DrinkTypeId",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "DrinkTypeId",
                table: "Drinks");
        }
    }
}
