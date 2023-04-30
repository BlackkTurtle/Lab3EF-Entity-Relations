using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P03_FootballBetting.Data.Migrations
{
    /// <inheritdoc />
    public partial class FootballDBMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "towns",
                columns: table => new
                {
                    TownId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Towns", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_Towns_Countries",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Initials = table.Column<string>(type: "TEXT", nullable: false),
                    Budget = table.Column<double>(type: "REAL", nullable: false),
                    PrimaryKitColorId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondaryKitColorId = table.Column<int>(type: "INTEGER", nullable: false),
                    TownId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Colors1",
                        column: x => x.PrimaryKitColorId,
                        principalTable: "colors",
                        principalColumn: "ColorId");
                    table.ForeignKey(
                        name: "FK_Teams_Colors2",
                        column: x => x.SecondaryKitColorId,
                        principalTable: "colors",
                        principalColumn: "ColorId");
                    table.ForeignKey(
                        name: "FK_Teams_Towns",
                        column: x => x.TownId,
                        principalTable: "towns",
                        principalColumn: "TownId");
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    HomeTeamGoals = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamGoals = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HomeTeamBetRate = table.Column<double>(type: "REAL", nullable: false),
                    AwayTeamBetRate = table.Column<double>(type: "REAL", nullable: false),
                    DrawBetRate = table.Column<double>(type: "REAL", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Teams1",
                        column: x => x.HomeTeamId,
                        principalTable: "teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Games_Teams2",
                        column: x => x.AwayTeamId,
                        principalTable: "teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SquadNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsInjured = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Positions",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "PositionId");
                    table.ForeignKey(
                        name: "FK_Players_Teams",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "bets",
                columns: table => new
                {
                    BetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BetAmount = table.Column<double>(type: "REAL", nullable: false),
                    Prediction = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bets", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bets_Games",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_Bets_Users",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "playerStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoredGoals = table.Column<int>(type: "INTEGER", nullable: false),
                    Assists = table.Column<int>(type: "INTEGER", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlayerStatistics", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_Games",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_Players",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bets_GameId",
                table: "bets",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_bets_UserId",
                table: "bets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_games_AwayTeamId",
                table: "games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_games_HomeTeamId",
                table: "games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_players_PositionId",
                table: "players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_players_TeamId",
                table: "players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_playerStatistics_GameId",
                table: "playerStatistics",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_PrimaryKitColorId",
                table: "teams",
                column: "PrimaryKitColorId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_SecondaryKitColorId",
                table: "teams",
                column: "SecondaryKitColorId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_TownId",
                table: "teams",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_towns_CountryId",
                table: "towns",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bets");

            migrationBuilder.DropTable(
                name: "playerStatistics");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "towns");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
