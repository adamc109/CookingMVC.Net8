using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removedID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "ShoppingCarts",
                newName: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "ShoppingCarts",
                newName: "RecipeID");
        }
    }
}
