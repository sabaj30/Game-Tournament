using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTournamentInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTournamentGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Games_GameId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_GameId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Tournaments");

            migrationBuilder.CreateTable(
                name: "TournamentGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreatedId = table.Column<int>(type: "int", nullable: false),
                    UserModifiedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentGames_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_GameId",
                table: "TournamentGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGames_TournamentId",
                table: "TournamentGames",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentGames");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_GameId",
                table: "Tournaments",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Games_GameId",
                table: "Tournaments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
