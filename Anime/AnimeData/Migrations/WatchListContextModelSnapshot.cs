﻿// <auto-generated />
using System;
using AnimeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimeData.Migrations
{
    [DbContext(typeof(WatchListContext))]
    partial class WatchListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimeData.Anime", b =>
                {
                    b.Property<int>("AnimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AnimeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("animeName");

                    b.Property<int?>("Episode")
                        .HasColumnType("int")
                        .HasColumnName("episode");

                    b.Property<string>("Genre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("genre");

                    b.Property<string>("Language")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("language");

                    b.Property<int?>("Rank")
                        .HasColumnType("int")
                        .HasColumnName("rank");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int")
                        .HasColumnName("releaseYear");

                    b.Property<int?>("Restriction")
                        .HasColumnType("int")
                        .HasColumnName("restriction");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.Property<string>("Summary")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("summary");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.HasKey("AnimeId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("AnimeData.Profile", b =>
                {
                    b.Property<string>("PersonId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("PersonID");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("country");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("lastName");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("PersonId")
                        .HasName("PK__Profiles__AA2FFB85C413CEC4");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("AnimeData.Watchlist", b =>
                {
                    b.Property<int?>("AnimeId")
                        .HasColumnType("int")
                        .HasColumnName("AnimeID");

                    b.Property<string>("PersonId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("PersonID");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("Watching")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("watching");

                    b.HasIndex("AnimeId");

                    b.HasIndex("PersonId");

                    b.ToTable("Watchlists");
                });

            modelBuilder.Entity("AnimeData.Watchlist", b =>
                {
                    b.HasOne("AnimeData.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId")
                        .HasConstraintName("FK__Watchlist__Anime__5441852A");

                    b.HasOne("AnimeData.Profile", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK__Watchlist__Perso__534D60F1");

                    b.Navigation("Anime");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
