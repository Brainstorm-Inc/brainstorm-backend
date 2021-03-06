// <auto-generated />
using System;
using Brainstorm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.Migrations.Migrations
{
    [DbContext(typeof(BrainstormContext))]
    [Migration("20220116211331_FixedOrgUsersNavIssue")]
    partial class FixedOrgUsersNavIssue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                            Id = new Guid("3bfba075-e736-456e-b818-883c8579d3c0"),
                            MajorVersion = 0,
                            MinorVersion = 1
                        });
                });

            modelBuilder.Entity("Brainstorm.Entities.Organization.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LogoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b649d60-d379-474d-9fd3-ca16dd9277d9"),
                            LogoLink = "https://robohash.org/test-org",
                            Name = "Test Organization"
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

                    b.Property<Guid?>("OrgId")
                        .HasColumnType("uuid");

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

                    b.HasIndex("OrgId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5cb0c1de-a77a-461c-a68d-003c240a0573"),
                            Email = "test@test.ro",
                            FirstName = "test",
                            LastName = "test",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("Brainstorm.Entities.User.User", b =>
                {
                    b.HasOne("Brainstorm.Entities.Organization.Organization", "Org")
                        .WithMany("Users")
                        .HasForeignKey("OrgId");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("Brainstorm.Entities.Organization.Organization", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
