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
            user.Admin = false;
            user.MessageCount = 0;
            user.UpvoteCount = 0;

            this.context.Users.Add(user);
        }
        public bool IsUserValid(User user)
        {
            bool userVal = this.context.Users.Any(u => u.UserName == user.UserName);

            return !userVal;
        }

        public bool IsEmailValid(User user)
        {
            bool isBilkentMail = user.Email.Contains("@ug.bilkent.edu.tr");

            if (!isBilkentMail)
            {
                return false;
            }

            bool emailVal = this.context.Users.Any(e => e.Email == user.Email);

            return !emailVal;
        }

        public bool UserExist(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return this.context.Users.Any(u => u.Id == userId);
        }

        ///
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

        public IEnumerable<Chatroom> GetChatromsWithUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            //var query = this.context.Users.Where(u => u.Id == userId).SelectMany(u => Chatroom);
            var query = from chatroom in this.context.Chatrooms
                        where chatroom.UserChatrooms.Any(c => c.UserId == userId)
                        select chatroom;

            return query.ToList();
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

        public bool IsChatroomNameValid(Chatroom chatroom)
        {
            bool chatroomVal = this.context.Chatrooms.Any(u => u.ChatroomName == chatroom.ChatroomName);

            return !chatroomVal;
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

            User user = this.context.Users.Where(u => u.Id == userId).FirstOrDefault();
            user.MessageCount = user.MessageCount + 1;

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
            var messages = this.context.Messages.Where(m => m.ChatroomId == ChatroomId).OrderBy(o => o.DateOfPost).Include(u => u.User).ToList();

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


            var listofAll = this.context.UserChatrooms.ToList();

            foreach(var item in listofAll)
            {
                if(item.ChatroomId == chatroomId && item.UserId == userId)
                {
                    return false;
                }
            }

            var userChatroom = new UserChatroom
            {
                ChatroomId = chatroomId,
                UserId = userId
            };
            this.context.UserChatrooms.Add(userChatroom);

            return true; 
        }

        // REWARD RELATED FUNCTİONS

        public User GetUsersWithRewards(Guid userId)
        {
            var userRewards = this.context.Users.Where(u => u.Id == userId)
                .Include(ur=> ur.UserRewards)
                .ThenInclude(r => r.Reward)
                .FirstOrDefault();
            return userRewards;
        }

        public List<Reward> GetRewards()
        {
            
            return this.context.Rewards.ToList<Reward>();
        }

        public Reward GetReward(Guid rewardId)
        {
            if (rewardId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            return this.context.Rewards.Where(r => r.Id == rewardId).FirstOrDefault();
        }

        public bool AddUserReward(Guid rewardId, Guid userId)
        {
            if (rewardId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var listofAll = this.context.UserRewards.ToList();

            foreach (var item in listofAll)
            {
                if (item.RewardId == rewardId && item.UserId == userId)
                {
                    return false;
                }
            }

            var userReward = new UserReward
            {
                RewardId = rewardId,
                UserId = userId
            };

            this.context.UserRewards.Add(userReward);

            return true;

        }

        public IEnumerable<Reward> GetRewardsWithUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var query = from reward in this.context.Rewards
                        where reward.UserRewards.Any(c => c.UserId == userId)
                        select reward;

            return query.ToList();
        }


        public bool RewardExist(Guid rewardId)
        {
            if (rewardId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rewardId));
            }

            return this.context.Rewards.Any(r => r.Id == rewardId);
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
