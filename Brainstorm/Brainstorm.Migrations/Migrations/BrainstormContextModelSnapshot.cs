﻿// <auto-generated />
using System;
using Brainstorm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Booking.Migrations.Migrations
{
    [DbContext(typeof(BrainstormContext))]
    partial class BrainstormContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("4541747f-1608-4836-9bc3-ac01cae1c53a"),
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");


                    b.Property<string>("ProfilePicture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("https://robohash.org/first-last");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01143f01-7b4a-4aad-8e87-6de87e34d9cc"),
                            Email = "test@test.ro",
                            FirstName = "test",
                            LastName = "test",
                            Password = "password"

                        });
                });
#pragma warning restore 612, 618
        }
    }
}
