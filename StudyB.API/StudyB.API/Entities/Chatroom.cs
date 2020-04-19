using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Entities
{
    public class Chatroom
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String ChatroomName { get; set; }
        public ICollection<Message> Messages { get; set; }
            = new List<Message>();
        public ICollection<UserChatroom> UserChatrooms { get; set; }
            = new List<UserChatroom>();
    }
}
