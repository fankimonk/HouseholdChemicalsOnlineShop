using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CartProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Carts_CartId1",
                table: "CartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Products_ProductId1",
                table: "CartProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_CartId1",
                table: "CartProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_ProductId1",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "CartProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId1",
                table: "CartProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "CartProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId1",
                table: "CartProducts",
                column: "CartId1");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId1",
                table: "CartProducts",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Carts_CartId1",
                table: "CartProducts",
                column: "CartId1",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Products_ProductId1",
                table: "CartProducts",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
