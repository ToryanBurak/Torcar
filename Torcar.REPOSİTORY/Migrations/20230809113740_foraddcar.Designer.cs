﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Torcar.REPOSITORY;

#nullable disable

namespace Torcar.REPOSITORY.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230809113740_foraddcar")]
    partial class foraddcar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Torcar.CORE.Entity.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte>("ActiveState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<decimal>("PriceOfDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CC")
                        .HasColumnType("double");

                    b.Property<int?>("CarSerialId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<byte>("Case")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("Color")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte>("Fuel")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("Gear")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("KM")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("CarSerialId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.ToTable("CarMarks");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarMarkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("CarMarkId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarSerial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarSerials");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("RentRequestId")
                        .HasColumnType("int");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("RentRequestId")
                        .IsUnique();

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.RentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdvertId")
                        .HasColumnType("int");

                    b.Property<byte>("ConfirmState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime>("RentEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RentStart")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RentRequests");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ConfirmCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<byte>("ObjectState")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PersonSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte>("Verify")
                        .HasColumnType("tinyint unsigned");

                    b.Property<bool>("rentrequestwarrant")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Advert", b =>
                {
                    b.HasOne("Torcar.CORE.Entity.Car", "Car")
                        .WithOne("Advert")
                        .HasForeignKey("Torcar.CORE.Entity.Advert", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Car", b =>
                {
                    b.HasOne("Torcar.CORE.Entity.CarSerial", "CarSerial")
                        .WithMany("Cars")
                        .HasForeignKey("CarSerialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarSerial");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarModel", b =>
                {
                    b.HasOne("Torcar.CORE.Entity.CarMark", "CarMark")
                        .WithMany("CarModels")
                        .HasForeignKey("CarMarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarMark");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarSerial", b =>
                {
                    b.HasOne("Torcar.CORE.Entity.CarModel", "CarModel")
                        .WithMany("CarSerials")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Rent", b =>
                {
                    b.HasOne("Torcar.CORE.Entity.RentRequest", "RentRequest")
                        .WithOne("Rent")
                        .HasForeignKey("Torcar.CORE.Entity.Rent", "RentRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentRequest");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.RentRequest", b =>
                {
                    b.HasOne("Torcar.CORE.Entity.Advert", "Advert")
                        .WithOne("RentRequest")
                        .HasForeignKey("Torcar.CORE.Entity.RentRequest", "AdvertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Torcar.CORE.Entity.User", "User")
                        .WithOne("RentRequest")
                        .HasForeignKey("Torcar.CORE.Entity.RentRequest", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Advert", b =>
                {
                    b.Navigation("RentRequest")
                        .IsRequired();
                });

            modelBuilder.Entity("Torcar.CORE.Entity.Car", b =>
                {
                    b.Navigation("Advert")
                        .IsRequired();
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarMark", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarModel", b =>
                {
                    b.Navigation("CarSerials");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.CarSerial", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Torcar.CORE.Entity.RentRequest", b =>
                {
                    b.Navigation("Rent")
                        .IsRequired();
                });

            modelBuilder.Entity("Torcar.CORE.Entity.User", b =>
                {
                    b.Navigation("RentRequest")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
