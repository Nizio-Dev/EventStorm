﻿// <auto-generated />
using EventStorm.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventStorm.Infrastructure.Migrations
{
    [DbContext(typeof(EventStormDbContext))]
    [Migration("20221227232226_fluent api added")]
    partial class fluentapiadded
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

                    b.Property<string>("StatusId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AttenderId");

                    b.HasIndex("MeetingId");

                    b.HasIndex("StatusId");

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

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("HasEnded")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Options");
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

                    b.HasOne("EventStorm.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Attender");

                    b.Navigation("Meeting");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Category", b =>
                {
                    b.HasOne("EventStorm.Domain.Entities.Meeting", null)
                        .WithMany("Categories")
                        .HasForeignKey("MeetingId");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Meeting", b =>
                {
                    b.HasOne("EventStorm.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("EventStorm.Domain.Entities.Attender", b =>
                {
                    b.Navigation("Attendances");
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
