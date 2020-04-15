using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyEnvironment.Data.Migrations
{
    public partial class IsApprovedColumnInInformationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Information",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Information");
        }
    }
}
