using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Models
{
    public class UserWithRewardDto
    {
        public Guid Id { get; set; }
        public bool Admin { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<RewardDto> Rewards { get; set; }
            = new List<RewardDto>();
    }
}
