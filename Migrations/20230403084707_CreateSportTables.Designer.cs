﻿// <auto-generated />
using Betting.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Betting.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230403084707_CreateSportTables")]
    partial class CreateSportTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Betting.Models.BetT", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IsLive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatchID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MatchID");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("Betting.Models.EventT", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsLive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("SportID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Betting.Models.MatchT", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MatchType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Betting.Models.OddT", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BetID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialBetValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BetID");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("Betting.Models.SportT", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("Betting.Models.BetT", b =>
                {
                    b.HasOne("Betting.Models.MatchT", "Match")
                        .WithMany("Bet")
                        .HasForeignKey("MatchID");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Betting.Models.EventT", b =>
                {
                    b.HasOne("Betting.Models.SportT", "Sport")
                        .WithMany("Event")
                        .HasForeignKey("SportID");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Betting.Models.MatchT", b =>
                {
                    b.HasOne("Betting.Models.EventT", "Event")
                        .WithMany("Match")
                        .HasForeignKey("EventID");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Betting.Models.OddT", b =>
                {
                    b.HasOne("Betting.Models.BetT", "Bet")
                        .WithMany("Odd")
                        .HasForeignKey("BetID");

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("Betting.Models.BetT", b =>
                {
                    b.Navigation("Odd");
                });

            modelBuilder.Entity("Betting.Models.EventT", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("Betting.Models.MatchT", b =>
                {
                    b.Navigation("Bet");
                });

            modelBuilder.Entity("Betting.Models.SportT", b =>
                {
                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
