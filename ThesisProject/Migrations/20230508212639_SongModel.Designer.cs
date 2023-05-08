﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThesisProject.Context;

#nullable disable

namespace ThesisProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230508212639_SongModel")]
    partial class SongModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThesisProject.Models.SongModel", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SongId"));

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SongFile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SongId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("ThesisProject.Models.UserModel", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}