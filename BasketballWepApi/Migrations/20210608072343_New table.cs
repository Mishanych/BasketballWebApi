using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballWepApi.Migrations
{
    public partial class Newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    MatchIsStarted = table.Column<bool>(type: "bit", nullable: false),
                    MatchIsEnded = table.Column<bool>(type: "bit", nullable: false),
                    matchDatamatchId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.MatchIsStarted);
                    table.ForeignKey(
                        name: "FK_Favourite_MatchesData_matchDatamatchId",
                        column: x => x.matchDatamatchId,
                        principalTable: "MatchesData",
                        principalColumn: "matchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_matchDatamatchId",
                table: "Favourite",
                column: "matchDatamatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourite");
        }
    }
}
