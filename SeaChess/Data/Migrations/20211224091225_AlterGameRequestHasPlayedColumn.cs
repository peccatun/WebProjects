using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaChess.Data.Migrations
{
    public partial class AlterGameRequestHasPlayedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPlayed",
                table: "GameRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPlayed",
                table: "GameRequests");
        }
    }
}
