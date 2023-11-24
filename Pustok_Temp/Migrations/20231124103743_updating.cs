using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_Temp.Migrations
{
    /// <inheritdoc />
    public partial class updating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoryId",
                table: "books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_CategoryId",
                table: "books",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_CategoryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_CategoryId",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoriesId",
                table: "books",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_CategoriesId",
                table: "books",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
