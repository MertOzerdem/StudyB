using Microsoft.EntityFrameworkCore;
using StudyB.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.DbContexts
{
    public class BuddyLibraryContext : DbContext
    {
        public BuddyLibraryContext(DbContextOptions<BuddyLibraryContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<Reward> Rewards  { get; set; }
        public DbSet<UserChatroom> UserChatrooms  { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChatroom>().HasKey(u => new { u.ChatroomId, u.UserId });

            var User = new[]
            {
                new User
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Pasta",
                    LastName = "Sempa",
                    UserName = "Pasta",
                    Password = "123"
                },
                new User
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Pepe",
                    LastName = "Julian Onziema",
                    UserName = "LGBT Right Activist",
                    Password = "159"
                },
                new User
                {
                    Id = Guid.Parse("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                    FirstName = "Ismini",
                    LastName = "bulamadım",
                    UserName = "The Host",
                    Password = "159"
                }
            };

            var Chatroom = new[]
            {
                new Chatroom
                {
                    Id = Guid.Parse("1acf8e02-9be4-428a-bd6b-8dce083bfac3"),
                    ChatroomName = "Cs 492"
                },
                new Chatroom
                {
                    Id = Guid.Parse("ce446daa-5e35-4f2a-ab83-cf75cac4837e"),
                    ChatroomName = "Cs 453"
                },
                new Chatroom
                {
                    Id = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
                    ChatroomName = "Morning Breeze"
                }
            };

            var Message = new[]
            {
                new Message
                {
                    Id = Guid.Parse("9bcfa927-179d-4346-a34e-e09928450456"),
                    Text = "What is up?",
                    FileAddress = null,
                    DateOfPost = new DateTime(1690, 11, 23),
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ChatroomId = Guid.Parse("1acf8e02-9be4-428a-bd6b-8dce083bfac3")
                },
                new Message
                {
                    Id = Guid.Parse("0936b9d0-c45a-4112-9306-fad95e9c07c7"),
                    Text = "Mavi Tik",
                    FileAddress = null,
                    DateOfPost = new DateTime(1988, 12, 09),
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ChatroomId = Guid.Parse("1acf8e02-9be4-428a-bd6b-8dce083bfac3")
                },
                // Messages From Morning Breeze
                new Message
                {
                    Id = Guid.Parse("9ca606d2-c909-46e6-ab6e-5f8616f083a6"),
                    Text = "We are bringing the studio this morning one of the gay right activist, Mr... Should I call You Mista?",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 1, 5),
                    UserId = Guid.Parse("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("d9292237-ad99-4347-a6a5-9eb12669e789"),
                    Text = "Pepe Julian Onziema thank you for coming. Why are you gay?",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 2, 5),
                    UserId = Guid.Parse("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("74fa1016-b592-4948-b582-c163ddc8e5fa"),
                    Text = "Who says I am gay?",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 2, 10),
                    UserId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("4cf3d108-2d49-4a76-a024-8a8d96fec24b"),
                    Text = "You are Gay. You're Transgenda, and gay rights activist, and outspoken lesbian?, Homosexual?",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 3, 5),
                    UserId = Guid.Parse("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("176cdccd-5156-450a-b3ac-f7e33f1338bd"),
                    Text = "Now we are looking at the debate. Why should someone be gay?",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 4, 5),
                    UserId = Guid.Parse("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("eab75a96-544a-480d-98dd-e375abaac938"),
                    Text = "I am not ... active right now.",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 5, 5),
                    UserId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("88990eac-0974-45f0-afd5-5c3dae5ada75"),
                    Text = "Doesn't that make you gay?",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 6, 5),
                    UserId = Guid.Parse("8ded4df7-4355-41b0-9b44-a9de574bcc48"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },
                new Message
                {
                    Id = Guid.Parse("88990eac-0974-45f0-afd5-5c3dae5ada75"),
                    Text = "Before you go, do you recognize any of these.",
                    FileAddress = null,
                    DateOfPost = new DateTime(2014, 12, 09, 22, 7, 5),
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ChatroomId = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b")
                },

            };

            var UserChatroom = new[]
            {
                new UserChatroom
                {
                    UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ChatroomId = Guid.Parse("ce446daa-5e35-4f2a-ab83-cf75cac4837e")
                },
                new UserChatroom
                {
                    UserId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    ChatroomId = Guid.Parse("ce446daa-5e35-4f2a-ab83-cf75cac4837e")
                }
            };

            modelBuilder.Entity<User>().HasData(User[0], User[1], User[2]);
            modelBuilder.Entity<Chatroom>().HasData(Chatroom[0], Chatroom[1], Chatroom[2]);
            modelBuilder.Entity<Message>().HasData(Message[0], Message[1], Message[2], Message[3], Message[4],
                                                   Message[5], Message[6], Message[7], Message[8]);
            modelBuilder.Entity<UserChatroom>().HasData(UserChatroom[0], UserChatroom[1]);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().HasData(
            //    new User()
            //    {
            //        Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
            //        FirstName = "Adam",
            //        LastName = "Çocuk",
            //        UserName = "Ateşli çocuk",
            //        Password = "123",
            //    },
            //    new User()
            //    {
            //        Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
            //        FirstName = "Kadın",
            //        LastName = "Adam",
            //        UserName = "Why are you gay?",
            //        Password = "159",
            //    }
            //    );

            //modelBuilder.Entity<Reward>().HasData(
            //    new Reward()
            //    {

            //    }
            //    );

            //modelBuilder.Entity<Chatroom>().HasData(
            //    new Chatroom()
            //    {
            //        Id = Guid.Parse("1acf8e02-9be4-428a-bd6b-8dce083bfac3"),
            //        ChatroomName = "Cs 492"
            //    },
            //    new Chatroom()
            //    {
            //        Id = Guid.Parse("ce446daa-5e35-4f2a-ab83-cf75cac4837e"),
            //        ChatroomName = "Cs 453"
            //    },
            //    new Chatroom()
            //    {
            //        Id = Guid.Parse("c25ed015-3e14-440d-a7c0-7eeedc0cf32b"),
            //        ChatroomName = "Cs 491"
            //    }
            //    );

            //modelBuilder.Entity<Message>().HasData(
            //    new Message()
            //    {
            //        Id = Guid.Parse("9bcfa927-179d-4346-a34e-e09928450456"),
            //        Text = "What is up?",
            //        FileAddress = null,
            //        DateOfPost = new DateTime(1690, 11, 23),
            //        UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
            //        ChatroomId = Guid.Parse("1acf8e02-9be4-428a-bd6b-8dce083bfac3")
            //    },
            //    new Message()
            //    {
            //        Id = Guid.Parse("0936b9d0-c45a-4112-9306-fad95e9c07c7"),
            //        Text = "Mavi Tik",
            //        FileAddress = null,
            //        DateOfPost = new DateTime(1988, 12, 09),
            //        UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
            //        ChatroomId = Guid.Parse("1acf8e02-9be4-428a-bd6b-8dce083bfac3")
            //    }
            //    );

            //modelBuilder.Entity<UserChatroom>().HasData();
        }
    }
}
