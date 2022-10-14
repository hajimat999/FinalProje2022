using Microsoft.EntityFrameworkCore.Migrations;

namespace FinallyFinalProject.Migrations
{
    public partial class nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlest_Products_ProductId",
                table: "Wishlest");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlest_AspNetUsers_UserId1",
                table: "Wishlest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlest",
                table: "Wishlest");

            migrationBuilder.RenameTable(
                name: "Wishlest",
                newName: "Wishlests");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlest_UserId1",
                table: "Wishlests",
                newName: "IX_Wishlests_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlest_ProductId",
                table: "Wishlests",
                newName: "IX_Wishlests_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlests",
                table: "Wishlests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlests_Products_ProductId",
                table: "Wishlests",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlests_AspNetUsers_UserId1",
                table: "Wishlests",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlests_Products_ProductId",
                table: "Wishlests");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlests_AspNetUsers_UserId1",
                table: "Wishlests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlests",
                table: "Wishlests");

            migrationBuilder.RenameTable(
                name: "Wishlests",
                newName: "Wishlest");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlests_UserId1",
                table: "Wishlest",
                newName: "IX_Wishlest_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlests_ProductId",
                table: "Wishlest",
                newName: "IX_Wishlest_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlest",
                table: "Wishlest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlest_Products_ProductId",
                table: "Wishlest",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlest_AspNetUsers_UserId1",
                table: "Wishlest",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
