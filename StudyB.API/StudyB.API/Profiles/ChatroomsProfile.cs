using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Profiles
{
    public class ChatroomsProfile : Profile
    {
        public ChatroomsProfile()
        {
            CreateMap<Entities.Chatroom, Models.ChatroomDto>();
            CreateMap<Entities.Chatroom, Models.ChatroomsWithContentDto>();
            
        }
    }
}
