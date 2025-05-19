using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finate.Web.Migrations
{
    /// <inheritdoc />
    public partial class cartItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartItem");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCardId",
                table: "CartItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductCardId",
                table: "CartItem",
                column: "ProductCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductCard_ProductCardId",
                table: "CartItem",
                column: "ProductCardId",
                principalTable: "ProductCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductCard_ProductCardId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ProductCardId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ProductCardId",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CartItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
