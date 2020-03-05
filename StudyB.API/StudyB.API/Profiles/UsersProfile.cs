using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Models.UserForCreationDto, Entities.User>();
        }
    }
}
