using Microsoft.EntityFrameworkCore.Migrations;

namespace Wjakimszkle.DataAccess.Migrations
{
    public partial class ReleasedDrinkToGlassAndDrinkToDishRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishDrink");

            migrationBuilder.DropTable(
                name: "DrinkGlass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishDrink",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    DrinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishDrink", x => new { x.DishesId, x.DrinksId });
                    table.ForeignKey(
                        name: "FK_DishDrink_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishDrink_Drinks_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkGlass",
                columns: table => new
                {
                    DrinksId = table.Column<int>(type: "int", nullable: false),
                    GlassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkGlass", x => new { x.DrinksId, x.GlassesId });
                    table.ForeignKey(
                        name: "FK_DrinkGlass_Drinks_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkGlass_Glasses_GlassesId",
                        column: x => x.GlassesId,
                        principalTable: "Glasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishDrink_DrinksId",
                table: "DishDrink",
                column: "DrinksId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkGlass_GlassesId",
                table: "DrinkGlass",
                column: "GlassesId");
        }
    }
}
