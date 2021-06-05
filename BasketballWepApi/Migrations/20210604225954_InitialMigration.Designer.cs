﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Context;

namespace BasketballWepApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210604225954_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketballWebApi.Models.LeagueData", b =>
                {
                    b.Property<string>("leagueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("leagueKind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("leagueName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("leagueShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("leagueId");

                    b.ToTable("LeaguesData");
                });

            modelBuilder.Entity("BasketballWebApi.Models.MatchData", b =>
                {
                    b.Property<string>("matchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("awayId")
                        .HasColumnType("int");

                    b.Property<string>("awayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("awayRank")
                        .HasColumnType("int");

                    b.Property<int>("awayScore")
                        .HasColumnType("int");

                    b.Property<string>("explain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("hasStats")
                        .HasColumnType("bit");

                    b.Property<string>("homeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("homeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("homeRank")
                        .HasColumnType("int");

                    b.Property<int>("homeScore")
                        .HasColumnType("int");

                    b.Property<string>("leagueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("leagueName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("leagueSeason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("matchTime")
                        .HasColumnType("int");

                    b.Property<int>("matchType")
                        .HasColumnType("int");

                    b.Property<bool>("neutral")
                        .HasColumnType("bit");

                    b.Property<int>("overTimeCount")
                        .HasColumnType("int");

                    b.Property<int>("quarterCount")
                        .HasColumnType("int");

                    b.Property<string>("quarterRemainTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roundType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("matchId");

                    b.HasIndex("leagueId");

                    b.ToTable("MatchesData");
                });

            modelBuilder.Entity("BasketballWebApi.Models.PlayerData", b =>
                {
                    b.Property<string>("playerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("birthday")
                        .HasColumnType("int");

                    b.Property<int>("height")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("nbaAge")
                        .HasColumnType("bigint");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("playerId");

                    b.HasIndex("teamId");

                    b.ToTable("PlayersData");
                });

            modelBuilder.Entity("BasketballWebApi.Models.TeamData", b =>
                {
                    b.Property<string>("teamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<int>("championCount")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("conference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("division")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("joinYear")
                        .HasColumnType("int");

                    b.Property<string>("leagueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("teamId");

                    b.HasIndex("leagueId");

                    b.ToTable("TeamsData");
                });

            modelBuilder.Entity("BasketballWebApi.Models.MatchData", b =>
                {
                    b.HasOne("BasketballWebApi.Models.LeagueData", "League")
                        .WithMany("Matches")
                        .HasForeignKey("leagueId");

                    b.Navigation("League");
                });

            modelBuilder.Entity("BasketballWebApi.Models.PlayerData", b =>
                {
                    b.HasOne("BasketballWebApi.Models.TeamData", "Team")
                        .WithMany("Players")
                        .HasForeignKey("teamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BasketballWebApi.Models.TeamData", b =>
                {
                    b.HasOne("BasketballWebApi.Models.LeagueData", "League")
                        .WithMany("Teams")
                        .HasForeignKey("leagueId");

                    b.Navigation("League");
                });

            modelBuilder.Entity("BasketballWebApi.Models.LeagueData", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("BasketballWebApi.Models.TeamData", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
