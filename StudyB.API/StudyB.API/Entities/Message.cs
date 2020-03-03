using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Entities
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string FileAddress { get; set; }
        public DateTimeOffset DateOfPost { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("ChatroomId")]
        public Chatroom Chatroom { get; set; }
        public Guid ChatroomId { get; set; }
    }
}
