using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Profiles
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            CreateMap<Entities.Message, Models.MessageDto>();
        }
    }
}
