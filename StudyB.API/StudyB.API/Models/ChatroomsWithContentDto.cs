using StudyB.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Models
{
    public class ChatroomsWithContentDto
    {
        public Guid Id { get; set; }
        public String ChatroomName { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
            = new List<MessageDto>();
    }
}
