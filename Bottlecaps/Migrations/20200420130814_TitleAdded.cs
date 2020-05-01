using Microsoft.EntityFrameworkCore.Migrations;

namespace Bottlecaps.Migrations
{
    public partial class TitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Bottlecap",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Bottlecap");
        }
    }
}
