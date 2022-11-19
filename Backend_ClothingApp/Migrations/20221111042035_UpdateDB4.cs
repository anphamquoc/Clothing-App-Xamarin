using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_ClothingApp.Migrations
{
    public partial class UpdateDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_CartId_ProductId",
                table: "CartDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId_ProductId",
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartId_ProductId",
                table: "CartDetails",
                columns: new[] { "CartId", "ProductId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_CartId_ProductId",
                table: "CartDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId_ProductId",
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartId_ProductId",
                table: "CartDetails",
                columns: new[] { "CartId", "ProductId" });
        }
    }
}
