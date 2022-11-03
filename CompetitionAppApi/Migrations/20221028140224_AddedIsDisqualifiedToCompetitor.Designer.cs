﻿// <auto-generated />
using System;
using CompetitionAppApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompetitionAppApi.Migrations
{
    [DbContext(typeof(CompetitionAppDbContext))]
    [Migration("20221028140224_AddedIsDisqualifiedToCompetitor")]
    partial class AddedIsDisqualifiedToCompetitor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompetitionAppApi.Models.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Laps")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("CompetitionAppApi.Models.Competitor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompetitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("IsDisqualified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PenaltyPointsSum")
                        .HasColumnType("int");

                    b.Property<int>("StartingNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Competitors");
                });

            modelBuilder.Entity("CompetitionAppApi.Models.Lap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompetitorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PenaltyPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitorId");

                    b.ToTable("Laps");
                });

            modelBuilder.Entity("CompetitionAppApi.Models.Competitor", b =>
                {
                    b.HasOne("CompetitionAppApi.Models.Competition", null)
                        .WithMany("Competitors")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompetitionAppApi.Models.Lap", b =>
                {
                    b.HasOne("CompetitionAppApi.Models.Competitor", null)
                        .WithMany("Laps")
                        .HasForeignKey("CompetitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompetitionAppApi.Models.Competition", b =>
                {
                    b.Navigation("Competitors");
                });

            modelBuilder.Entity("CompetitionAppApi.Models.Competitor", b =>
                {
                    b.Navigation("Laps");
                });
#pragma warning restore 612, 618
        }
    }
}