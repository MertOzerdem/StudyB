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
        /// <summary>
        /// USER RELATED FUNC
        /// </summary>
        /// 
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

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Id = Guid.NewGuid();

            this.context.Users.Add(user);
        }

        public bool UserExist(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return this.context.Users.Any(u => u.Id == userId);
        }

        /// <summary>
        /// CHATROOM RELATED FUNC
        /// </summary>
        ///
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
        public bool ChatroomExist(Guid chatroomId)
        {
            if (chatroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(chatroomId));
            }

            return this.context.Chatrooms.Any(c => c.Id == chatroomId);
        }

        public Chatroom AddChatroom(Chatroom chatroom)
        {
            if (chatroom == null)
            {
                throw new ArgumentNullException(nameof(chatroom));
            }

            chatroom.Id = Guid.NewGuid();
            this.context.Chatrooms.Add(chatroom);
            return chatroom;
        }

        //
        // MESSAGES RELATED FUNC
        //
        public void AddMessage(Guid chatroomId, Guid userId, Message message)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (chatroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(chatroomId));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            message.ChatroomId = chatroomId;
            message.UserId = userId;
            message.Id = Guid.NewGuid();
            message.DateOfPost = DateTimeOffset.Now;

            context.Messages.Add(message);
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

        public Message GetMessages(Guid messageId)
        {
            if (messageId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            var message = this.context.Messages.Where(m => m.Id == messageId).FirstOrDefault();
            return message;
        }

        public bool AddUserChatroom(Guid chatroomId, Guid userId)
        {
            if (chatroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(chatroomId));
            }

            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var userChatroom = new UserChatroom
            {
                ChatroomId = chatroomId,
                UserId = userId
            };

            if (!this.context.UserChatrooms.Any(u => u.UserId == userChatroom.UserId)
                && !this.context.UserChatrooms.Any(u => u.ChatroomId == userChatroom.ChatroomId))
            {
                this.context.UserChatrooms.Add(userChatroom);
                return true;
            }

            return false;
            // make query so that not any duplicate will be tried to saved

            
        }

        public bool Save()
        {
            return (this.context.SaveChanges() >= 0);
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
