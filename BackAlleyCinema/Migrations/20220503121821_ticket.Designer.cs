﻿// <auto-generated />
using System;
using BackAlleyCinema.DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackAlleyCinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20220503121821_ticket")]
    partial class ticket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackAlleyCinema.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageTo64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BackAlleyCinema.Models.Saloon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<int>("MaxSeats")
                        .HasColumnType("int");

                    b.Property<int>("SaloonNr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Saloons");
                });

            modelBuilder.Entity("BackAlleyCinema.Models.Schedule", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("SaloonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ViewsId")
                        .HasColumnType("datetime2");

                    b.Property<string>("TakenSeats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketsSold")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "SaloonId", "ViewsId");

                    b.HasIndex("SaloonId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("BackAlleyCinema.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovieStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchasedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaloonNr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BackAlleyCinema.Models.Schedule", b =>
                {
                    b.HasOne("BackAlleyCinema.Models.Movie", "Movies")
                        .WithMany("Schedules")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackAlleyCinema.Models.Saloon", "Saloons")
                        .WithMany()
                        .HasForeignKey("SaloonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("Saloons");
                });

            modelBuilder.Entity("BackAlleyCinema.Models.Ticket", b =>
                {
                    b.HasOne("BackAlleyCinema.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BackAlleyCinema.Models.Movie", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
