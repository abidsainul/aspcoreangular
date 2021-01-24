﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetcore_spa.Persistence;

namespace aspnetcore_spa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210121181224_ApplySeed")]
    partial class ApplySeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

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
                            Name = "Make1-ModelA"
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
                            Name = "Make2-ModelA"
                        });
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

            modelBuilder.Entity("aspnetcore_spa.Models.Make", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
