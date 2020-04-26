using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyEnvironment.Data.Migrations
{
    public partial class AdditionalImageUrlJsonColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalImageUrlsJson",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalImageUrlsJson",
                table: "Products");
        }
    }
}
