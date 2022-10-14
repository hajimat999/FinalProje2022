using Microsoft.EntityFrameworkCore.Migrations;

namespace FinallyFinalProject.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DiscountAmount_DiscountAmountId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountAmount",
                table: "DiscountAmount");

            migrationBuilder.RenameTable(
                name: "DiscountAmount",
                newName: "discountAmounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_discountAmounts",
                table: "discountAmounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_discountAmounts_Amount",
                table: "discountAmounts",
                column: "Amount",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_discountAmounts_DiscountAmountId",
                table: "Products",
                column: "DiscountAmountId",
                principalTable: "discountAmounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_discountAmounts_DiscountAmountId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_discountAmounts",
                table: "discountAmounts");

            migrationBuilder.DropIndex(
                name: "IX_discountAmounts_Amount",
                table: "discountAmounts");

            migrationBuilder.RenameTable(
                name: "discountAmounts",
                newName: "DiscountAmount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountAmount",
                table: "DiscountAmount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DiscountAmount_DiscountAmountId",
                table: "Products",
                column: "DiscountAmountId",
                principalTable: "DiscountAmount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
