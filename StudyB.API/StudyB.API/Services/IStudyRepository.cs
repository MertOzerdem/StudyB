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
        User GetUser(Guid Id);
        IEnumerable<User> GetUsers();
        Chatroom GetChatroom(Guid Id);
        IEnumerable<Chatroom> GetChatrooms();
        Chatroom GetChatroomWithContent(Guid Id);
        //List<ChatroomsWithContentDto> GetChatroomsWithContent();
        List<Chatroom> GetChatroomsWithContent();
    }
}
