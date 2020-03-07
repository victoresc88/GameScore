﻿// <auto-generated />
using System;
using GameScoreFetchDataJob.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameScoreFetchDataJob.Migrations
{
    [DbContext(typeof(GameScoreSeedContext))]
    [Migration("20200307173213_ChangeNameOfTables")]
    partial class ChangeNameOfTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameScoreFetchDataJob.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ScoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScoreId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.GenreGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreGame");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.PlatformGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlatformId");

                    b.ToTable("PlatformGame");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gameplay")
                        .HasColumnType("int");

                    b.Property<int>("Graphics")
                        .HasColumnType("int");

                    b.Property<int>("Narrative")
                        .HasColumnType("int");

                    b.Property<int>("Sound")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.Game", b =>
                {
                    b.HasOne("GameScoreFetchDataJob.Models.Score", "Score")
                        .WithMany()
                        .HasForeignKey("ScoreId");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.GenreGame", b =>
                {
                    b.HasOne("GameScoreFetchDataJob.Models.Game", "Game")
                        .WithMany("Genres")
                        .HasForeignKey("GameId");

                    b.HasOne("GameScoreFetchDataJob.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("GameScoreFetchDataJob.Models.PlatformGame", b =>
                {
                    b.HasOne("GameScoreFetchDataJob.Models.Game", "Game")
                        .WithMany("Platforms")
                        .HasForeignKey("GameId");

                    b.HasOne("GameScoreFetchDataJob.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId");
                });
#pragma warning restore 612, 618
        }
    }
}
