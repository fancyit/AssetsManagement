using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetsManagement.DL.Migrations
{
    public partial class addedretiredfieldtoasset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Retired",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Retired",
                table: "Assets");
        }
    }
}
