using StudyB.API.Entities;
using StudyB.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Services
{
    public interface IStudyRepository
    {
        bool Save();
        // USER RELATED FUNC
        User GetUser(Guid Id);
        IEnumerable<User> GetUsers();
        Chatroom GetChatroom(Guid Id);
        void AddUser(User user);
        bool UserExist(Guid userId);
        bool IsUserValid(User user);
        bool IsEmailValid(User user);

        // CHATROOM RELATED FUNC
        IEnumerable<Chatroom> GetChatrooms();
        Chatroom GetChatroomWithContent(Guid Id);
        //List<ChatroomsWithContentDto> GetChatroomsWithContent();
        List<Chatroom> GetChatroomsWithContent();
        bool ChatroomExist(Guid chatroomId);
        void AddMessage(Guid chatroomId, Guid userId, Message message);
        Chatroom AddChatroom(Chatroom chatroom);
        bool IsChatroomNameValid(Chatroom chatroom);

        // MESSAGES RELATED FUNC
        List<Message> GetMessages();
        List<Message> GetChatroomMessages(Guid ChatroomId);
        Message GetMessages(Guid messageId);

        // USERCHATROOM RELATED FUNC
        bool AddUserChatroom(Guid chatroomId, Guid userId);

        // REWARD RELATED FUNC
        User GetUsersWithRewards(Guid userId);
        List<Reward> GetRewards();
        Reward GetReward(Guid rewardId);
    }
}
