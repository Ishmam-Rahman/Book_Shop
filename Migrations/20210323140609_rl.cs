using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStroe.Migrations
{
    public partial class rl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_BookType_BookTypeId",
                table: "BookModel");

            migrationBuilder.AlterColumn<int>(
                name: "BookTypeId",
                table: "BookModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_BookType_BookTypeId",
                table: "BookModel",
                column: "BookTypeId",
                principalTable: "BookType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_BookType_BookTypeId",
                table: "BookModel");

            migrationBuilder.AlterColumn<int>(
                name: "BookTypeId",
                table: "BookModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_BookType_BookTypeId",
                table: "BookModel",
                column: "BookTypeId",
                principalTable: "BookType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
