﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workers.Persistance;

#nullable disable

namespace Workers.WebApi.Migrations
{
    [DbContext(typeof(WorkerDbContext))]
    [Migration("20240222092458_newModels")]
    partial class newModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Workers.Domain.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Female"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Non-binary"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Prefer not to say"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Other"
                        });
                });

            modelBuilder.Entity("Workers.Domain.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Position");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Software Engineer"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Data Scientist"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Product Manager"
                        },
                        new
                        {
                            Id = 4,
                            Title = "UX/UI Designer"
                        },
                        new
                        {
                            Id = 5,
                            Title = "QA Engineer"
                        });
                });

            modelBuilder.Entity("Workers.Domain.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WorkerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId1")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("GenderId1")
                        .IsUnique()
                        .HasFilter("[GenderId1] IS NOT NULL");

                    b.HasIndex("PositionId");

                    b.ToTable("Workers", (string)null);
                });

            modelBuilder.Entity("Workers.Domain.WorkerPositions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerPositions");
                });

            modelBuilder.Entity("Workers.Domain.Worker", b =>
                {
                    b.HasOne("Workers.Domain.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Workers.Domain.Gender", null)
                        .WithOne("Worker")
                        .HasForeignKey("Workers.Domain.Worker", "GenderId1");

                    b.HasOne("Workers.Domain.Position", "Position")
                        .WithMany("Workers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Workers.Domain.WorkerPositions", b =>
                {
                    b.HasOne("Workers.Domain.Position", "Position")
                        .WithMany("WorkerPositions")
                        .HasForeignKey("PositionId");

                    b.HasOne("Workers.Domain.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId");

                    b.Navigation("Position");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Workers.Domain.Gender", b =>
                {
                    b.Navigation("Worker")
                        .IsRequired();
                });

            modelBuilder.Entity("Workers.Domain.Position", b =>
                {
                    b.Navigation("WorkerPositions");

                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
