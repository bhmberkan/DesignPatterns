using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryDesignPattern.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CatergoryID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "PRoductStock",
                table: "products",
                newName: "ProductStock");

            migrationBuilder.RenameColumn(
                name: "PRoductPrice",
                table: "products",
                newName: "ProductPrice");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryID",
                table: "products",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ProductStock",
                table: "products",
                newName: "PRoductStock");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "products",
                newName: "PRoductPrice");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CatergoryID",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryID",
                table: "products",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
