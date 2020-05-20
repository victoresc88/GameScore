using Microsoft.EntityFrameworkCore.Migrations;

namespace GameScore.DAL.Migrations
{
    public partial class AddOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GameId",
                table: "Scores");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Scores",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameId",
                table: "Scores",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Games_GameId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GameId",
                table: "Scores");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Scores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
