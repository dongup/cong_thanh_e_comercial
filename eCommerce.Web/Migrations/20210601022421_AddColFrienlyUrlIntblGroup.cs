using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Web.Migrations
{
    public partial class AddColFrienlyUrlIntblGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FriendlyUrl",
                table: "Groups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendlyUrl",
                table: "Groups");
        }
    }
}
