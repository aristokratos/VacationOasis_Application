﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationOasis.Core.DatabaseContext;

#nullable disable

namespace VacationOasis.Core.Migrations
{
    [DbContext(typeof(VacationOasisDbContext))]
    partial class VacationOasisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VacationOasis.Domain.Models.Hotel", b =>
                {
                    b.Property<int>("HotelImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelImageId"), 1L, 1);

                    b.Property<int>("HotelDetailBedRoomNum")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailDinninRoomNum")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailLivingRoomNum")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailMPS")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailRefrigiratorNum")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailTelevisionNum")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailUnitReady")
                        .HasColumnType("int");

                    b.Property<int>("HotelDetailbathRoomNum")
                        .HasColumnType("int");

                    b.Property<string>("HotelImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelImageCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelImageLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HotelImagePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HotelImageStyle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelImageStyle1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit");

                    b.HasKey("HotelImageId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("VacationOasis.Domain.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
