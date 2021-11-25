using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotMaintOnline4.Data.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    StartKilometers = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorcycle_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDone = table.Column<DateTime>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    MaintenanceTypeId = table.Column<int>(nullable: false),
                    MotorcycleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenance_MaintenanceType_MaintenanceTypeId",
                        column: x => x.MaintenanceTypeId,
                        principalTable: "MaintenanceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenance_Motorcycle_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_ApplicationUserId",
                table: "Maintenance",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_MaintenanceTypeId",
                table: "Maintenance",
                column: "MaintenanceTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_MotorcycleId",
                table: "Maintenance",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_ApplicationUserId",
                table: "Motorcycle",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "MaintenanceType");

            migrationBuilder.DropTable(
                name: "Motorcycle");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
