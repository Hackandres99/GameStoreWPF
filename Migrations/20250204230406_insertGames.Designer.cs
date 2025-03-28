﻿// <auto-generated />
using System;
using GameStoreWPF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStoreWPF.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20250204230406_insertGames")]
    partial class insertGames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStoreWPF.Models.ConsoleVideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.HasKey("Id")
                        .HasName("PK__consoleV__3214EC0793F4E642");

                    b.ToTable("consoleVideoGame");
                });

            modelBuilder.Entity("GameStoreWPF.Models.PublicationYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("PK__publicat__3214EC072AE4262D");

                    b.ToTable("publicationYear");
                });

            modelBuilder.Entity("GameStoreWPF.Models.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Console")
                        .HasColumnType("int")
                        .HasColumnName("console");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("name");

                    b.Property<int?>("PublicationYear")
                        .HasColumnType("int")
                        .HasColumnName("publicationYear");

                    b.Property<int?>("VideoGameAge")
                        .HasColumnType("int")
                        .HasColumnName("videoGameAge");

                    b.Property<int?>("VideoGameType")
                        .HasColumnType("int")
                        .HasColumnName("videoGameType");

                    b.HasKey("Id")
                        .HasName("PK__videoGam__3214EC07F7D4C6AC");

                    b.HasIndex("Console");

                    b.HasIndex("PublicationYear");

                    b.HasIndex("VideoGameAge");

                    b.HasIndex("VideoGameType");

                    b.ToTable("videoGame");
                });

            modelBuilder.Entity("GameStoreWPF.Models.VideoGameAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.HasKey("Id")
                        .HasName("PK__videoGam__3214EC07E858C920");

                    b.ToTable("videoGameAge");
                });

            modelBuilder.Entity("GameStoreWPF.Models.VideoGameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("PK__videoGam__3214EC07CBB01108");

                    b.ToTable("videoGameType");
                });

            modelBuilder.Entity("GameStoreWPF.Models.VideoGame", b =>
                {
                    b.HasOne("GameStoreWPF.Models.ConsoleVideoGame", "ConsoleNavigation")
                        .WithMany("VideoGames")
                        .HasForeignKey("Console")
                        .HasConstraintName("FK_videoGame_ToConsole");

                    b.HasOne("GameStoreWPF.Models.PublicationYear", "PublicationYearNavigation")
                        .WithMany("VideoGames")
                        .HasForeignKey("PublicationYear")
                        .HasConstraintName("FK_videoGame_ToYear");

                    b.HasOne("GameStoreWPF.Models.VideoGameAge", "VideoGameAgeNavigation")
                        .WithMany("VideoGames")
                        .HasForeignKey("VideoGameAge")
                        .HasConstraintName("FK_videoGame_ToAge");

                    b.HasOne("GameStoreWPF.Models.VideoGameType", "VideoGameTypeNavigation")
                        .WithMany("VideoGames")
                        .HasForeignKey("VideoGameType")
                        .HasConstraintName("FK_videoGame_ToType");

                    b.Navigation("ConsoleNavigation");

                    b.Navigation("PublicationYearNavigation");

                    b.Navigation("VideoGameAgeNavigation");

                    b.Navigation("VideoGameTypeNavigation");
                });

            modelBuilder.Entity("GameStoreWPF.Models.ConsoleVideoGame", b =>
                {
                    b.Navigation("VideoGames");
                });

            modelBuilder.Entity("GameStoreWPF.Models.PublicationYear", b =>
                {
                    b.Navigation("VideoGames");
                });

            modelBuilder.Entity("GameStoreWPF.Models.VideoGameAge", b =>
                {
                    b.Navigation("VideoGames");
                });

            modelBuilder.Entity("GameStoreWPF.Models.VideoGameType", b =>
                {
                    b.Navigation("VideoGames");
                });
#pragma warning restore 612, 618
        }
    }
}
