using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignPattern.Facade.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_customers_CustomerID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerID",
                table: "orders",
                newName: "IX_orders_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "OrderID");

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_orderDetails_customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_orderDetails_orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_orderDetails_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_CustomerID",
                table: "orderDetails",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderID",
                table: "orderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductID",
                table: "orderDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerID",
                table: "orders",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerID",
                table: "orders");

            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CustomerID",
                table: "Order",
                newName: "IX_Order_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_customers_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
