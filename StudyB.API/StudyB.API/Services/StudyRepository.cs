using StudyB.API.DbContexts;
using StudyB.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyB.API.Models;

namespace StudyB.API.Services
{
    public class StudyRepository : IDisposable, IStudyRepository
    {
        private readonly BuddyLibraryContext context;

        public StudyRepository(BuddyLibraryContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return this.context.Users.ToList<User>();
        }

        public User GetUser(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            return this.context.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Chatroom> GetChatrooms()
        {
            return this.context.Chatrooms.ToList<Chatroom>();
        }

        public Chatroom GetChatroom(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            return this.context.Chatrooms.Where(c => c.Id == Id).FirstOrDefault();
        }

        //public List<ChatroomsWithContentDto> GetChatroomsWithContent()
        //{
        //    //var chatroomsWithContent = this.context.Chatrooms.Include(m => m.Messages).ToList();

        //    // working set
        //    //var chatroomsWithContent = this.context.Chatrooms.Select(c => new ChatroomsWithContentDto
        //    //{
        //    //    ChatroomName = c.ChatroomName,
        //    //    Id = c.Id,
        //    //    Messages = c.Messages.OrderBy(s => s.DateOfPost).ToList()

        //    //}).ToList();

        //    //return chatroomsWithContent;
        //}

        public List<Chatroom> GetChatroomsWithContent()
        {
            var chatroomsWithContent = this.context.Chatrooms.Select(c => new Chatroom
            {
                ChatroomName = c.ChatroomName,
                Id = c.Id,
                Messages = c.Messages.OrderBy(s => s.DateOfPost).ToList()
            }).ToList();

            return chatroomsWithContent;
        }

        public Chatroom GetChatroomWithContent(Guid Id)
        {
            //var chatroomWithContent = this.context.Chatrooms.Where(c=> c.Id == Id).Include(m => m.Messages).ToList();

            //var messages = new List<Message>();
            //foreach (var a in chatroomWithContent)
            //{
            //    List<Message> message = a.Messages.ToList();

            //}
            //return messages;
            return null;
        }

        public List<Message> GetMessages()
        {
            var messages = this.context.Messages.OrderBy(o => o.DateOfPost).ToList<Message>();

            return messages;
        }

        public List<Message> GetChatroomMessages(Guid ChatroomId)
        {
            var messages = this.context.Messages.Where(m => m.ChatroomId == ChatroomId).OrderBy(o => o.DateOfPost).ToList();

            return messages;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
