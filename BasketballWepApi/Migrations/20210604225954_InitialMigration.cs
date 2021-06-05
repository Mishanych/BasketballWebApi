using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballWepApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaguesData",
                columns: table => new
                {
                    leagueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    leagueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    leagueShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    leagueKind = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaguesData", x => x.leagueId);
                });

            migrationBuilder.CreateTable(
                name: "MatchesData",
                columns: table => new
                {
                    matchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    leagueId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    leagueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quarterCount = table.Column<int>(type: "int", nullable: false),
                    matchTime = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    quarterRemainTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeRank = table.Column<int>(type: "int", nullable: false),
                    awayId = table.Column<int>(type: "int", nullable: false),
                    awayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    awayRank = table.Column<int>(type: "int", nullable: false),
                    homeScore = table.Column<int>(type: "int", nullable: false),
                    awayScore = table.Column<int>(type: "int", nullable: false),
                    overTimeCount = table.Column<int>(type: "int", nullable: false),
                    leagueSeason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matchType = table.Column<int>(type: "int", nullable: false),
                    hasStats = table.Column<bool>(type: "bit", nullable: false),
                    explain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roundType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    neutral = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesData", x => x.matchId);
                    table.ForeignKey(
                        name: "FK_MatchesData_LeaguesData_leagueId",
                        column: x => x.leagueId,
                        principalTable: "LeaguesData",
                        principalColumn: "leagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsData",
                columns: table => new
                {
                    teamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    leagueId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    joinYear = table.Column<int>(type: "int", nullable: false),
                    championCount = table.Column<int>(type: "int", nullable: false),
                    coach = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsData", x => x.teamId);
                    table.ForeignKey(
                        name: "FK_TeamsData_LeaguesData_leagueId",
                        column: x => x.leagueId,
                        principalTable: "LeaguesData",
                        principalColumn: "leagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersData",
                columns: table => new
                {
                    playerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nbaAge = table.Column<long>(type: "bigint", nullable: false),
                    salary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersData", x => x.playerId);
                    table.ForeignKey(
                        name: "FK_PlayersData_TeamsData_teamId",
                        column: x => x.teamId,
                        principalTable: "TeamsData",
                        principalColumn: "teamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchesData_leagueId",
                table: "MatchesData",
                column: "leagueId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersData_teamId",
                table: "PlayersData",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsData_leagueId",
                table: "TeamsData",
                column: "leagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchesData");

            migrationBuilder.DropTable(
                name: "PlayersData");

            migrationBuilder.DropTable(
                name: "TeamsData");

            migrationBuilder.DropTable(
                name: "LeaguesData");
        }
    }
}
