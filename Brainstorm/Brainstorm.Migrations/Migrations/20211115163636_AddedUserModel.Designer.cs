﻿// <auto-generated />
using System;
using Brainstorm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Booking.Migrations.Migrations
{
    [DbContext(typeof(BrainstormContext))]
    [Migration("20211115163636_AddedUserModel")]
    partial class AddedUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Brainstorm.Entities.AppVersion.AppVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("MajorVersion")
                        .HasColumnType("integer");

                    b.Property<int>("MinorVersion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("AppVersions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("73f3221f-becb-4561-9e9b-35514c981c77"),
                            MajorVersion = 0,
                            MinorVersion = 1
                        });
                });

            modelBuilder.Entity("Brainstorm.Entities.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("first-last@mail.com");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("LastName");

                    b.Property<string>("ProfilePicture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("https://robohash.org/first-last");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("78c14057-e37a-42d3-9969-8064a3ca7f03"),
                            Email = "Fname-Lname@mail.com",
                            FirstName = "Fname",
                            LastName = "Lname",
                            ProfilePicture = "https://robohash.org/Fname-Lname.png"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}