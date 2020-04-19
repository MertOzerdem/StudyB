using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Entities
{
    public class UserReward
    {
        public Reward Reward { get; set; }
        public Guid RewardId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
