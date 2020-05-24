﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyB.API.DbContexts;

namespace StudyB.API.Migrations
{
    [DbContext(typeof(BuddyLibraryContext))]
    [Migration("20200524212456_v1.0")]
    partial class v10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyB.API.Entities.Chatroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatroomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Chatrooms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"),
                            ChatroomName = "Cs 492"
                        },
                        new
                        {
                            Id = new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"),
                            ChatroomName = "Cs 453"
                        },
                        new
                        {
                            Id = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            ChatroomName = "Morning Breeze"
                        });
                });

            modelBuilder.Entity("StudyB.API.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatroomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfPost")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FileAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChatroomId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9bcfa927-179d-4346-a34e-e09928450456"),
                            ChatroomId = new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"),
                            DateOfPost = new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "What is up?",
                            UserId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            Id = new Guid("0936b9d0-c45a-4112-9306-fad95e9c07c7"),
                            ChatroomId = new Guid("1acf8e02-9be4-428a-bd6b-8dce083bfac3"),
                            DateOfPost = new DateTimeOffset(new DateTime(1988, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Mavi Tik",
                            UserId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            Id = new Guid("9ca606d2-c909-46e6-ab6e-5f8616f083a6"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 1, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "We are bringing the studio this morning one of the gay right activist, Mr... Should I call You Mista?",
                            UserId = new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48")
                        },
                        new
                        {
                            Id = new Guid("d9292237-ad99-4347-a6a5-9eb12669e789"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 2, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "Pepe Julian Onziema thank you for coming. Why are you gay?",
                            UserId = new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48")
                        },
                        new
                        {
                            Id = new Guid("74fa1016-b592-4948-b582-c163ddc8e5fa"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 2, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "Who says I am gay?",
                            UserId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            Id = new Guid("4cf3d108-2d49-4a76-a024-8a8d96fec24b"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 3, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "You are Gay. You're Transgenda, and gay rights activist, and outspoken lesbian?, Homosexual?",
                            UserId = new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48")
                        },
                        new
                        {
                            Id = new Guid("176cdccd-5156-450a-b3ac-f7e33f1338bd"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 4, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "Now we are looking at the debate. Why should someone be gay?",
                            UserId = new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48")
                        },
                        new
                        {
                            Id = new Guid("eab75a96-544a-480d-98dd-e375abaac938"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 5, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "I am not ... active right now.",
                            UserId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            Id = new Guid("88990eac-0974-45f0-afd5-5c3dae5ada75"),
                            ChatroomId = new Guid("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                            DateOfPost = new DateTimeOffset(new DateTime(2014, 12, 9, 22, 6, 5, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Text = "Doesn't that make you gay?",
                            UserId = new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48")
                        });
                });

            modelBuilder.Entity("StudyB.API.Entities.Reward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RewardName")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Rewards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("02b9e886-0291-45d9-8d97-6adc7e63babf"),
                            RewardName = "Best Admin Ever"
                        },
                        new
                        {
                            Id = new Guid("e5d9f399-be62-4283-b7c6-81177f71a402"),
                            RewardName = "Worst Admin Ever"
                        },
                        new
                        {
                            Id = new Guid("118fc971-0831-4207-9b1d-7237bc4271b2"),
                            RewardName = "Average User"
                        });
                });

            modelBuilder.Entity("StudyB.API.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessageCount")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("UpvoteCount")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Admin = false,
                            Email = "pasta@ug.bilkent.edu.tr",
                            FirstName = "Pasta",
                            LastName = "Sempa",
                            MessageCount = 0,
                            Password = "123",
                            UpvoteCount = 0,
                            UserName = "Pasta"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Admin = false,
                            Email = "Pepe@ug.bilkent.edu.tr",
                            FirstName = "Pepe",
                            LastName = "Julian Onziema",
                            MessageCount = 0,
                            Password = "159",
                            UpvoteCount = 0,
                            UserName = "LGBT Right Activist"
                        },
                        new
                        {
                            Id = new Guid("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                            Admin = true,
                            Email = "Ismini@ug.bilkent.edu.tr",
                            FirstName = "Ismini",
                            LastName = "bulamadım",
                            MessageCount = 0,
                            Password = "159",
                            UpvoteCount = 0,
                            UserName = "The Host"
                        });
                });

            modelBuilder.Entity("StudyB.API.Entities.UserChatroom", b =>
                {
                    b.Property<Guid>("ChatroomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatroomId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChatrooms");

                    b.HasData(
                        new
                        {
                            ChatroomId = new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"),
                            UserId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            ChatroomId = new Guid("ce446daa-5e35-4f2a-ab83-cf75cac4837e"),
                            UserId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        });
                });

            modelBuilder.Entity("StudyB.API.Entities.UserReward", b =>
                {
                    b.Property<Guid>("RewardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RewardId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRewards");

                    b.HasData(
                        new
                        {
                            RewardId = new Guid("118fc971-0831-4207-9b1d-7237bc4271b2"),
                            UserId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            RewardId = new Guid("02b9e886-0291-45d9-8d97-6adc7e63babf"),
                            UserId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        });
                });

            modelBuilder.Entity("StudyB.API.Entities.Message", b =>
                {
                    b.HasOne("StudyB.API.Entities.Chatroom", "Chatroom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyB.API.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyB.API.Entities.UserChatroom", b =>
                {
                    b.HasOne("StudyB.API.Entities.Chatroom", "Chatroom")
                        .WithMany("UserChatrooms")
                        .HasForeignKey("ChatroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyB.API.Entities.User", "User")
                        .WithMany("UserChatrooms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyB.API.Entities.UserReward", b =>
                {
                    b.HasOne("StudyB.API.Entities.Reward", "Reward")
                        .WithMany()
                        .HasForeignKey("RewardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyB.API.Entities.User", "User")
                        .WithMany("UserRewards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}