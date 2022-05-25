using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetsManagement.DL.Migrations
{
    public partial class renamedretiredfieldtoIsRetired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Retired",
                table: "Assets",
                newName: "IsRetired");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRetired",
                table: "Assets",
                newName: "Retired");
        }
    }
}
