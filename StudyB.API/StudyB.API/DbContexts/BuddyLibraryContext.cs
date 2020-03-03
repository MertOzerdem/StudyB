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

            var User = new[]
            {
                new User
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Adam",
                    LastName = "Çocuk",
                    UserName = "Ateşli çocuk",
                    Password = "123"
                },
                new User
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Kadın",
                    LastName = "Adam",
                    UserName = "Why are you gay?",
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
                    ChatroomName = "Cs 491"
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
                }
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

            modelBuilder.Entity<User>().HasData(User[0], User[1]);
            modelBuilder.Entity<Chatroom>().HasData(Chatroom[0], Chatroom[1], Chatroom[2]);
            modelBuilder.Entity<Message>().HasData(Message[0], Message[1]);
            modelBuilder.Entity<UserChatroom>().HasData(UserChatroom[0], UserChatroom[1]);

            base.OnModelCreating(modelBuilder);
        }    
    }
}
