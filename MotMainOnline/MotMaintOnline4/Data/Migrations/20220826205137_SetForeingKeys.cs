using Microsoft.EntityFrameworkCore.Migrations;

namespace MotMaintOnline4.Data.Migrations
{
    public partial class SetForeingKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Motorcycles_MotorcycleId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_MotorcycleId",
                table: "Maintenances");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenances",
                column: "MaintenanceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Motorcycles_MaintenanceTypeId",
                table: "Maintenances",
                column: "MaintenanceTypeId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Motorcycles_MaintenanceTypeId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenances");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenances",
                column: "MaintenanceTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MotorcycleId",
                table: "Maintenances",
                column: "MotorcycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Motorcycles_MotorcycleId",
                table: "Maintenances",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
