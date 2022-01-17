﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Brainstorm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.Migrations.Migrations
{
    [DbContext(typeof(BrainstormContext))]
    partial class BrainstormContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("4a5a0def-653a-41ea-9a0f-dc49880d2e25"),
                            MajorVersion = 0,
                            MinorVersion = 1
                        });
                });

            modelBuilder.Entity("Brainstorm.Entities.Comment.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("IterationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProposalId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReplyToId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("IterationId");

                    b.HasIndex("ProposalId");

                    b.HasIndex("ReplyToId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Brainstorm.Entities.Iteration.Iteration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<List<string>>("Files")
                        .HasColumnType("text[]");

                    b.Property<string>("Goal")
                        .HasColumnType("text");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<long>("Position")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("TimelineId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TimelineId");

                    b.HasIndex("TopicId");

                    b.ToTable("Iteration");
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
                            Id = new Guid("2ded1149-87b6-4bd0-b1bb-050667c0caf3"),
                            LogoLink = "https://robohash.org/test-org",
                            Name = "Test Organization"
                        });
                });

            modelBuilder.Entity("Brainstorm.Entities.Project.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OrgId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrgId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Brainstorm.Entities.Proposal.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<List<string>>("Files")
                        .HasColumnType("text[]");

                    b.Property<Guid?>("RatingId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TimelineId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RatingId");

                    b.HasIndex("TimelineId");

                    b.ToTable("Proposal");
                });

            modelBuilder.Entity("Brainstorm.Entities.Rating.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Avg")
                        .HasColumnType("double precision");

                    b.Property<int>("Fives")
                        .HasColumnType("integer");

                    b.Property<int>("Fours")
                        .HasColumnType("integer");

                    b.Property<int>("Ones")
                        .HasColumnType("integer");

                    b.Property<int>("Threes")
                        .HasColumnType("integer");

                    b.Property<int>("Twos")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Brainstorm.Entities.Timeline.Timeline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Timeline");
                });

            modelBuilder.Entity("Brainstorm.Entities.Topic.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrentIterationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("HighlightedProposalId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("HighlightedProposalId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Topic");
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

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("OrgId");

                    b.HasIndex("TopicId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70e8f048-acfe-48a7-9b61-e1a0f967b7d8"),
                            Email = "test@test.ro",
                            FirstName = "test",
                            LastName = "test",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("Brainstorm.Entities.Comment.Comment", b =>
                {
                    b.HasOne("Brainstorm.Entities.User.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Brainstorm.Entities.Iteration.Iteration", null)
                        .WithMany("Comments")
                        .HasForeignKey("IterationId");

                    b.HasOne("Brainstorm.Entities.Proposal.Proposal", "Proposal")
                        .WithMany("Comments")
                        .HasForeignKey("ProposalId");

                    b.HasOne("Brainstorm.Entities.Comment.Comment", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToId");

                    b.Navigation("Author");

                    b.Navigation("Proposal");

                    b.Navigation("ReplyTo");
                });

            modelBuilder.Entity("Brainstorm.Entities.Iteration.Iteration", b =>
                {
                    b.HasOne("Brainstorm.Entities.Timeline.Timeline", "Timeline")
                        .WithMany()
                        .HasForeignKey("TimelineId");

                    b.HasOne("Brainstorm.Entities.Topic.Topic", "Topic")
                        .WithMany("Iterations")
                        .HasForeignKey("TopicId");

                    b.Navigation("Timeline");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Brainstorm.Entities.Project.Project", b =>
                {
                    b.HasOne("Brainstorm.Entities.Organization.Organization", "Org")
                        .WithMany("Projects")
                        .HasForeignKey("OrgId");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("Brainstorm.Entities.Proposal.Proposal", b =>
                {
                    b.HasOne("Brainstorm.Entities.User.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Brainstorm.Entities.Rating.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId");

                    b.HasOne("Brainstorm.Entities.Timeline.Timeline", null)
                        .WithMany("Proposals")
                        .HasForeignKey("TimelineId");

                    b.Navigation("Author");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Brainstorm.Entities.Topic.Topic", b =>
                {
                    b.HasOne("Brainstorm.Entities.User.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Brainstorm.Entities.Proposal.Proposal", "HighlightedProposal")
                        .WithMany()
                        .HasForeignKey("HighlightedProposalId");

                    b.HasOne("Brainstorm.Entities.Project.Project", "Project")
                        .WithMany("Topics")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Author");

                    b.Navigation("HighlightedProposal");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Brainstorm.Entities.User.User", b =>
                {
                    b.HasOne("Brainstorm.Entities.Organization.Organization", "Org")
                        .WithMany("Users")
                        .HasForeignKey("OrgId");

                    b.HasOne("Brainstorm.Entities.Topic.Topic", null)
                        .WithMany("Users")
                        .HasForeignKey("TopicId");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("Brainstorm.Entities.Iteration.Iteration", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Brainstorm.Entities.Organization.Organization", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Brainstorm.Entities.Project.Project", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Brainstorm.Entities.Proposal.Proposal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Brainstorm.Entities.Timeline.Timeline", b =>
                {
                    b.Navigation("Proposals");
                });

            modelBuilder.Entity("Brainstorm.Entities.Topic.Topic", b =>
                {
                    b.Navigation("Iterations");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
