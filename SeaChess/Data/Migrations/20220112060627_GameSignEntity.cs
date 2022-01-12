using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaChess.Data.Migrations
{
    public partial class GameSignEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSigns",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(nullable: false),
                    PlayerOneSign = table.Column<string>(maxLength: 10, nullable: true),
                    PlayerOneId = table.Column<string>(nullable: true),
                    PlayerTwoSign = table.Column<string>(maxLength: 10, nullable: true),
                    PlayerTwoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSigns", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSigns");
        }
    }
}
