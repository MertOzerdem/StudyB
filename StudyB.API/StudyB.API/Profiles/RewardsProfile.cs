using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Profiles
{
    public class RewardsProfile : Profile
    {
        public RewardsProfile()
        {
            CreateMap<Entities.Reward, Models.RewardDto>();
            CreateMap<Entities.User, Models.UserWithRewardDto>();
        }
    }
}
