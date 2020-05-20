using Microsoft.EntityFrameworkCore.Migrations;

namespace GameScore.DAL.Migrations
{
    public partial class UpdateRateScoreProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "Scores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "Rates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Rates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Rates");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Scores",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Rates",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
