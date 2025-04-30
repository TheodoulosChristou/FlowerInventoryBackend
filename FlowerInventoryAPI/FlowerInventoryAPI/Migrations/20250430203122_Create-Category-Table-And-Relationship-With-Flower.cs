using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerInventoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateCategoryTableAndRelationshipWithFlower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Flower",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flower_CategoryId",
                table: "Flower",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flower_Category_CategoryId",
                table: "Flower",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flower_Category_CategoryId",
                table: "Flower");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Flower_CategoryId",
                table: "Flower");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Flower");
        }
    }
}
