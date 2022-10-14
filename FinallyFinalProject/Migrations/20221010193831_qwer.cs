using Microsoft.EntityFrameworkCore.Migrations;

namespace FinallyFinalProject.Migrations
{
    public partial class qwer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlests_AspNetUsers_UserId1",
                table: "Wishlests");

            migrationBuilder.DropIndex(
                name: "IX_Wishlests_UserId1",
                table: "Wishlests");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Wishlests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Wishlests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlests_UserId",
                table: "Wishlests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlests_AspNetUsers_UserId",
                table: "Wishlests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlests_AspNetUsers_UserId",
                table: "Wishlests");

            migrationBuilder.DropIndex(
                name: "IX_Wishlests_UserId",
                table: "Wishlests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Wishlests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Wishlests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlests_UserId1",
                table: "Wishlests",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlests_AspNetUsers_UserId1",
                table: "Wishlests",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
