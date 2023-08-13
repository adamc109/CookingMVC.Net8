using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedForeginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Recipies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Recipies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Recipies",
                columns: new[] { "Id", "CategoryId", "Ingredients", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { 2, 1, "sausage burger, bun", 8.0, 8.0, 3.0, 7.0, "McMuffin" });

            migrationBuilder.CreateIndex(
                name: "IX_Recipies_CategoryId",
                table: "Recipies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipies_Categories_CategoryId",
                table: "Recipies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipies_Categories_CategoryId",
                table: "Recipies");

            migrationBuilder.DropIndex(
                name: "IX_Recipies_CategoryId",
                table: "Recipies");

            migrationBuilder.DeleteData(
                table: "Recipies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipies");
        }
    }
}
