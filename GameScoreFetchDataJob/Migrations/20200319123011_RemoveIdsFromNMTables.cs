using Microsoft.EntityFrameworkCore.Migrations;

namespace GameScore.SeedDB.Job.Migrations
{
    public partial class RemoveIdsFromNMTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlatformGames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GenreGames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlatformGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GenreGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
