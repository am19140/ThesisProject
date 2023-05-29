﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThesisProject.Context;

#nullable disable

namespace ThesisProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThesisProject.Models.HistoryModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("songId")
                        .HasColumnType("integer");

                    b.Property<int>("timesListened")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("history");
                });

            modelBuilder.Entity("ThesisProject.Models.LikedModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("songId")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("ThesisProject.Models.SongModel", b =>
                {
                    b.Property<int>("songId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("songId"));

                    b.Property<string>("artist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("mood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("songfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("songname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("songId");

                    b.ToTable("songs");
                });

            modelBuilder.Entity("ThesisProject.Models.UserModel", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("profileImage")
                        .HasColumnType("text");

                    b.HasKey("username");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
