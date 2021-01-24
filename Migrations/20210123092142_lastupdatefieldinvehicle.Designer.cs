﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetcore_spa.Persistence;

namespace aspnetcore_spa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210123092142_lastupdatefieldinvehicle")]
    partial class lastupdatefieldinvehicle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FeatureVehicle", b =>
                {
                    b.Property<int>("FeaturesId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("FeaturesId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("VehicleFeatures");
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Feature1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Feature2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Feature3"
                        });
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Make-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Make-2"
                        });
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MakeId = 1,
                            Name = "Make1-ModelA"
                        },
                        new
                        {
                            Id = 2,
                            MakeId = 1,
                            Name = "Make1-ModelB"
                        },
                        new
                        {
                            Id = 3,
                            MakeId = 2,
                            Name = "Make2-ModelA"
                        },
                        new
                        {
                            Id = 4,
                            MakeId = 2,
                            Name = "Make2-ModelB"
                        });
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FeatureVehicle", b =>
                {
                    b.HasOne("aspnetcore_spa.Models.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspnetcore_spa.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Model", b =>
                {
                    b.HasOne("aspnetcore_spa.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Vehicle", b =>
                {
                    b.HasOne("aspnetcore_spa.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("aspnetcore_spa.Models.Make", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
