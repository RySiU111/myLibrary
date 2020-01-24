using Microsoft.EntityFrameworkCore.Migrations;

namespace myLibrary.API.Migrations
{
    public partial class AddedPhotoUrlToBookAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Authors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Authors");
        }
    }
}
