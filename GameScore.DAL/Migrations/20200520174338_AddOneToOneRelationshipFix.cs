using Microsoft.EntityFrameworkCore.Migrations;

namespace GameScore.DAL.Migrations
{
    public partial class AddOneToOneRelationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ScoreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameId",
                table: "Scores",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GameId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "ScoreId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScoreId",
                table: "Games",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
