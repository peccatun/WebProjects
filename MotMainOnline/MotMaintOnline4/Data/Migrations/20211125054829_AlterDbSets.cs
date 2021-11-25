using Microsoft.EntityFrameworkCore.Migrations;

namespace MotMaintOnline4.Data.Migrations
{
    public partial class AlterDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_ApplicationUser_ApplicationUserId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_MaintenanceType_MaintenanceTypeId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Motorcycle_MotorcycleId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycle_ApplicationUser_ApplicationUserId",
                table: "Motorcycle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motorcycle",
                table: "Motorcycle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceType",
                table: "MaintenanceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maintenance",
                table: "Maintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "Motorcycle",
                newName: "Motorcycles");

            migrationBuilder.RenameTable(
                name: "MaintenanceType",
                newName: "MaintenanceTypes");

            migrationBuilder.RenameTable(
                name: "Maintenance",
                newName: "Maintenances");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUsers");

            migrationBuilder.RenameIndex(
                name: "IX_Motorcycle_ApplicationUserId",
                table: "Motorcycles",
                newName: "IX_Motorcycles_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_MotorcycleId",
                table: "Maintenances",
                newName: "IX_Maintenances_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_MaintenanceTypeId",
                table: "Maintenances",
                newName: "IX_Maintenances_MaintenanceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_ApplicationUserId",
                table: "Maintenances",
                newName: "IX_Maintenances_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motorcycles",
                table: "Motorcycles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceTypes",
                table: "MaintenanceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maintenances",
                table: "Maintenances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_ApplicationUsers_ApplicationUserId",
                table: "Maintenances",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_MaintenanceTypes_MaintenanceTypeId",
                table: "Maintenances",
                column: "MaintenanceTypeId",
                principalTable: "MaintenanceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Motorcycles_MotorcycleId",
                table: "Maintenances",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_ApplicationUsers_ApplicationUserId",
                table: "Motorcycles",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_ApplicationUsers_ApplicationUserId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_MaintenanceTypes_MaintenanceTypeId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Motorcycles_MotorcycleId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_ApplicationUsers_ApplicationUserId",
                table: "Motorcycles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motorcycles",
                table: "Motorcycles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceTypes",
                table: "MaintenanceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maintenances",
                table: "Maintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "Motorcycles",
                newName: "Motorcycle");

            migrationBuilder.RenameTable(
                name: "MaintenanceTypes",
                newName: "MaintenanceType");

            migrationBuilder.RenameTable(
                name: "Maintenances",
                newName: "Maintenance");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_Motorcycles_ApplicationUserId",
                table: "Motorcycle",
                newName: "IX_Motorcycle_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_MotorcycleId",
                table: "Maintenance",
                newName: "IX_Maintenance_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenance",
                newName: "IX_Maintenance_MaintenanceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_ApplicationUserId",
                table: "Maintenance",
                newName: "IX_Maintenance_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motorcycle",
                table: "Motorcycle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceType",
                table: "MaintenanceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maintenance",
                table: "Maintenance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_ApplicationUser_ApplicationUserId",
                table: "Maintenance",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_MaintenanceType_MaintenanceTypeId",
                table: "Maintenance",
                column: "MaintenanceTypeId",
                principalTable: "MaintenanceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Motorcycle_MotorcycleId",
                table: "Maintenance",
                column: "MotorcycleId",
                principalTable: "Motorcycle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycle_ApplicationUser_ApplicationUserId",
                table: "Motorcycle",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
