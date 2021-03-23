using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStroe.Migrations
{
    public partial class accha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookTypeId",
                table: "BookModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookModel_BookTypeId",
                table: "BookModel",
                column: "BookTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_BookType_BookTypeId",
                table: "BookModel",
                column: "BookTypeId",
                principalTable: "BookType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_BookType_BookTypeId",
                table: "BookModel");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropIndex(
                name: "IX_BookModel_BookTypeId",
                table: "BookModel");

            migrationBuilder.DropColumn(
                name: "BookTypeId",
                table: "BookModel");
        }
    }
}
