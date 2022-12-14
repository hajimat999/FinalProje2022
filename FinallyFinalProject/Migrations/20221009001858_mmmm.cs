using Microsoft.EntityFrameworkCore.Migrations;

namespace FinallyFinalProject.Migrations
{
    public partial class mmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Colors_ColorId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ColorId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "BasketItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ColorId",
                table: "BasketItems",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Colors_ColorId",
                table: "BasketItems",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
