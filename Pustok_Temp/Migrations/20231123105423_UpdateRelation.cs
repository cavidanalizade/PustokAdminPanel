using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_Temp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoriesId",
                table: "books",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_CategoriesId",
                table: "books",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_CategoriesId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_CategoriesId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "books");
        }
    }
}
