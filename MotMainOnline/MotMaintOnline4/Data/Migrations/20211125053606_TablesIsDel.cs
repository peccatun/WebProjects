using Microsoft.EntityFrameworkCore.Migrations;

namespace MotMaintOnline4.Data.Migrations
{
    public partial class TablesIsDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDel",
                table: "Motorcycle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDel",
                table: "MaintenanceType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDel",
                table: "Maintenance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDel",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDel",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "IsDel",
                table: "MaintenanceType");

            migrationBuilder.DropColumn(
                name: "IsDel",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "IsDel",
                table: "ApplicationUser");
        }
    }
}
