﻿// <auto-generated />
using System;
using FlightManagementRadar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightManagementRadar.Migrations
{
    [DbContext(typeof(FlightManagementContext))]
    [Migration("20230427142131_addingRole2")]
    partial class addingRole2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("flightmanagementradar.models.CheckIn_Detail", b =>
                {
                    b.Property<int>("Boarding_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Boarding_Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phonenum")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("flightDataFlight_ID")
                        .HasColumnType("int");

                    b.Property<bool>("isCheckedIn")
                        .HasColumnType("bit");

                    b.Property<string>("userDetailUserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Boarding_Id");

                    b.HasIndex("flightDataFlight_ID");

                    b.HasIndex("userDetailUserName");

                    b.ToTable("CheckIn_Details");
                });

            modelBuilder.Entity("FlightManagementRadar.Models.Flight_Data", b =>
                {
                    b.Property<int>("Flight_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Flight_ID"), 1L, 1);

                    b.Property<DateTime>("Boarding_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fare")
                        .HasColumnType("int");

                    b.Property<string>("Flight_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Flight_ID");

                    b.ToTable("Flight_Datas");
                });

            modelBuilder.Entity("FlightManagementRadar.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("flightmanagementradar.models.CheckIn_Detail", b =>
                {
                    b.HasOne("FlightManagementRadar.Models.Flight_Data", "flightData")
                        .WithMany()
                        .HasForeignKey("flightDataFlight_ID");

                    b.HasOne("FlightManagementRadar.Models.User", "userDetail")
                        .WithMany()
                        .HasForeignKey("userDetailUserName");

                    b.Navigation("flightData");

                    b.Navigation("userDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
