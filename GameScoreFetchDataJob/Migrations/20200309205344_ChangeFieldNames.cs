using Microsoft.EntityFrameworkCore.Migrations;

namespace GameScoreFetchDataJob.Migrations
{
    public partial class ChangeFieldNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreGame_Games_GameId",
                table: "GenreGame");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGame_Genres_GenreId",
                table: "GenreGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformGame_Games_GameId",
                table: "PlatformGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformGame_Platforms_PlatformId",
                table: "PlatformGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreGame",
                table: "GenreGame");

            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "PlatformGame",
                newName: "PlatformGames");

            migrationBuilder.RenameTable(
                name: "GenreGame",
                newName: "GenreGames");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformGame_PlatformId",
                table: "PlatformGames",
                newName: "IX_PlatformGames_PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformGame_GameId",
                table: "PlatformGames",
                newName: "IX_PlatformGames_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreGame_GenreId",
                table: "GenreGames",
                newName: "IX_GenreGames_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreGame_GameId",
                table: "GenreGames",
                newName: "IX_GenreGames_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId",
                table: "PlatformGames",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "PlatformGames",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "GenreGames",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GenreGames",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGames",
                table: "PlatformGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreGames",
                table: "GenreGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGames_Games_GameId",
                table: "GenreGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGames_Genres_GenreId",
                table: "GenreGames",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformGames_Games_GameId",
                table: "PlatformGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformGames_Platforms_PlatformId",
                table: "PlatformGames",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreGames_Games_GameId",
                table: "GenreGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGames_Genres_GenreId",
                table: "GenreGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformGames_Games_GameId",
                table: "PlatformGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformGames_Platforms_PlatformId",
                table: "PlatformGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGames",
                table: "PlatformGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreGames",
                table: "GenreGames");

            migrationBuilder.RenameTable(
                name: "PlatformGames",
                newName: "PlatformGame");

            migrationBuilder.RenameTable(
                name: "GenreGames",
                newName: "GenreGame");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformGames_PlatformId",
                table: "PlatformGame",
                newName: "IX_PlatformGame_PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformGames_GameId",
                table: "PlatformGame",
                newName: "IX_PlatformGame_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreGames_GenreId",
                table: "GenreGame",
                newName: "IX_GenreGame_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreGames_GameId",
                table: "GenreGame",
                newName: "IX_GenreGame_GameId");

            migrationBuilder.AddColumn<int>(
                name: "OriginalId",
                table: "Platforms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginalId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId",
                table: "PlatformGame",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "PlatformGame",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "GenreGame",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GenreGame",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreGame",
                table: "GenreGame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGame_Games_GameId",
                table: "GenreGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGame_Genres_GenreId",
                table: "GenreGame",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformGame_Games_GameId",
                table: "PlatformGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformGame_Platforms_PlatformId",
                table: "PlatformGame",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
