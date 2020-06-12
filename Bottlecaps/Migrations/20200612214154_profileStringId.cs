using Microsoft.EntityFrameworkCore.Migrations;

namespace Bottlecaps.Migrations
{
    public partial class profileStringId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileStringId",
                schema: "dbo",
                table: "Bottlecap",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileStringId",
                schema: "dbo",
                table: "Bottlecap");
        }
    }
}
