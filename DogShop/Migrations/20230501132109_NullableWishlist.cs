using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShop.Migrations
{
    /// <inheritdoc />
    public partial class NullableWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wishlists_WishlistId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WishlistId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WishlistId",
                table: "Users",
                column: "WishlistId",
                unique: true,
                filter: "[WishlistId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wishlists_WishlistId",
                table: "Users",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wishlists_WishlistId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WishlistId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_WishlistId",
                table: "Users",
                column: "WishlistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wishlists_WishlistId",
                table: "Users",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
