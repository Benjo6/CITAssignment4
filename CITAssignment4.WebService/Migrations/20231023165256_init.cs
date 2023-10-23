using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CITAssignment4.WebService.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customername = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeid = table.Column<int>(type: "int", nullable: true),
                    orderdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requiredate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    shippeddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    freight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    shipname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    shipcity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    shipaddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    shippostalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    shipcountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderid);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplierid = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    quantityperunit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    unitprice = table.Column<int>(type: "int", nullable: false),
                    unitsinstock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productid);
                    table.ForeignKey(
                        name: "FK_Product_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    unitprice = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.orderid, x.productid });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_orderid",
                        column: x => x.orderid,
                        principalTable: "Order",
                        principalColumn: "orderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_productid",
                table: "OrderDetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryid",
                table: "Product",
                column: "categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
