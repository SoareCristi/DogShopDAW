using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShop.Migrations
{
    /// <inheritdoc />
    public partial class AssociativeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductOrder_Orders_OrderId",
                table: "AssociativeProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductOrder_Products_ProductId",
                table: "AssociativeProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductWishlist_Products_ProductId",
                table: "AssociativeProductWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductWishlist_Wishlists_WishlistId",
                table: "AssociativeProductWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociativeProductWishlist",
                table: "AssociativeProductWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociativeProductOrder",
                table: "AssociativeProductOrder");

            migrationBuilder.RenameTable(
                name: "AssociativeProductWishlist",
                newName: "AssociativeProductWishlists");

            migrationBuilder.RenameTable(
                name: "AssociativeProductOrder",
                newName: "AssociativeProductOrders");

            migrationBuilder.RenameIndex(
                name: "IX_AssociativeProductWishlist_WishlistId",
                table: "AssociativeProductWishlists",
                newName: "IX_AssociativeProductWishlists_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociativeProductOrder_OrderId",
                table: "AssociativeProductOrders",
                newName: "IX_AssociativeProductOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociativeProductWishlists",
                table: "AssociativeProductWishlists",
                columns: new[] { "ProductId", "WishlistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociativeProductOrders",
                table: "AssociativeProductOrders",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductOrders_Orders_OrderId",
                table: "AssociativeProductOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductOrders_Products_ProductId",
                table: "AssociativeProductOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductWishlists_Products_ProductId",
                table: "AssociativeProductWishlists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductWishlists_Wishlists_WishlistId",
                table: "AssociativeProductWishlists",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductOrders_Orders_OrderId",
                table: "AssociativeProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductOrders_Products_ProductId",
                table: "AssociativeProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductWishlists_Products_ProductId",
                table: "AssociativeProductWishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociativeProductWishlists_Wishlists_WishlistId",
                table: "AssociativeProductWishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociativeProductWishlists",
                table: "AssociativeProductWishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociativeProductOrders",
                table: "AssociativeProductOrders");

            migrationBuilder.RenameTable(
                name: "AssociativeProductWishlists",
                newName: "AssociativeProductWishlist");

            migrationBuilder.RenameTable(
                name: "AssociativeProductOrders",
                newName: "AssociativeProductOrder");

            migrationBuilder.RenameIndex(
                name: "IX_AssociativeProductWishlists_WishlistId",
                table: "AssociativeProductWishlist",
                newName: "IX_AssociativeProductWishlist_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociativeProductOrders_OrderId",
                table: "AssociativeProductOrder",
                newName: "IX_AssociativeProductOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociativeProductWishlist",
                table: "AssociativeProductWishlist",
                columns: new[] { "ProductId", "WishlistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociativeProductOrder",
                table: "AssociativeProductOrder",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductOrder_Orders_OrderId",
                table: "AssociativeProductOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductOrder_Products_ProductId",
                table: "AssociativeProductOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductWishlist_Products_ProductId",
                table: "AssociativeProductWishlist",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociativeProductWishlist_Wishlists_WishlistId",
                table: "AssociativeProductWishlist",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
