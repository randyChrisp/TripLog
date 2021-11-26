﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripLog.Models;

namespace TripLog.Migrations
{
    [DbContext(typeof(TripContext))]
    [Migration("20211126022450_Lab_12")]
    partial class Lab_12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TripLog.Models.Accommodation", b =>
                {
                    b.Property<int>("AccommodationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccommodationId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("TripLog.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToDo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TripLog.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TripLog.Models.TripActivity", b =>
                {
                    b.Property<int>("TripsLogId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.HasKey("TripsLogId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("TripActivities");
                });

            modelBuilder.Entity("TripLog.Models.TripsLog", b =>
                {
                    b.Property<int>("TripsLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("TripsLogId");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TripLog.Models.TripActivity", b =>
                {
                    b.HasOne("TripLog.Models.Activity", "Activity")
                        .WithMany("TripActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripLog.Models.TripsLog", "TripsLog")
                        .WithMany("TripActivities")
                        .HasForeignKey("TripsLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("TripsLog");
                });

            modelBuilder.Entity("TripLog.Models.TripsLog", b =>
                {
                    b.HasOne("TripLog.Models.Accommodation", "Accommodation")
                        .WithMany("TripsLogs")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TripLog.Models.Destination", "Destination")
                        .WithMany("TripsLogs")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TripLog.Models.Accommodation", b =>
                {
                    b.Navigation("TripsLogs");
                });

            modelBuilder.Entity("TripLog.Models.Activity", b =>
                {
                    b.Navigation("TripActivities");
                });

            modelBuilder.Entity("TripLog.Models.Destination", b =>
                {
                    b.Navigation("TripsLogs");
                });

            modelBuilder.Entity("TripLog.Models.TripsLog", b =>
                {
                    b.Navigation("TripActivities");
                });
#pragma warning restore 612, 618
        }
    }
}