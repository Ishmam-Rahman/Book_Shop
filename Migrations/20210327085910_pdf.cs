using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStroe.Migrations
{
    public partial class pdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfURL",
                table: "BookModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfURL",
                table: "BookModel");
        }
    }
}
