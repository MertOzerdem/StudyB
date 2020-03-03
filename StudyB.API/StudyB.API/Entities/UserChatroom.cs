using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Entities
{
    public class UserChatroom
    {
        public Chatroom Chatroom { get; set; }
        public Guid ChatroomId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
