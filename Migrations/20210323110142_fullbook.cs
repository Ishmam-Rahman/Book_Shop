using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStroe.Migrations
{
    public partial class fullbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "BookModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BookModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "BookModel");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookModel");
        }
    }
}
