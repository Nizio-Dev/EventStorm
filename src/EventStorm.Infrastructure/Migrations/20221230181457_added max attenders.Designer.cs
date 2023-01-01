﻿// <auto-generated />
using System;
using EventStorm.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    [DbContext(typeof(EventStormDbContext))]
    [Migration("20221230181457_added max attenders")]
    partial class addedmaxattenders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EventStorm.Domain.Entities.Attendance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AttenderId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MeetingId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AttenderId");

                    b.HasIndex("MeetingId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Attender", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Auth0Id")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Attenders");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MeetingId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Meeting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndingTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaxAttenders")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("EventStorm.Domain.Entities.Attender", "Attender")
                        .WithMany("Attendances")
                        .HasForeignKey("AttenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventStorm.Domain.Entities.Meeting", "Meeting")
                        .WithMany("Attendances")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attender");

                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Category", b =>
                {
                    b.HasOne("EventStorm.Domain.Entities.Meeting", null)
                        .WithMany("Categories")
                        .HasForeignKey("MeetingId");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Meeting", b =>
                {
                    b.HasOne("EventStorm.Domain.Entities.Attender", "Owner")
                        .WithMany("MeetingsOwnership")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Attender", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("MeetingsOwnership");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Meeting", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
