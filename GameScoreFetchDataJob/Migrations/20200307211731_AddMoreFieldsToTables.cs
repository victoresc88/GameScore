using Microsoft.EntityFrameworkCore.Migrations;

namespace GameScoreFetchDataJob.Migrations
{
    public partial class AddMoreFieldsToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalId",
                table: "Platforms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginalId",
                table: "Genres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Metacritic",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayTime",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Metacritic",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayTime",
                table: "Games");
        }
    }
}
