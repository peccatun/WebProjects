using Microsoft.EntityFrameworkCore.Migrations;

namespace MotMaintOnline4.Data.Migrations
{
    public partial class MaintenancePrieColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Maintenances",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Maintenances");
        }
    }
}
