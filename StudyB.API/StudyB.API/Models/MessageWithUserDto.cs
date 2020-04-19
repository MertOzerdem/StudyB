using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Models
{
    public class MessageWithUserDto
    {
        public Guid MessageId { get; set; }
        public string Text { get; set; }
        public string FileAddress { get; set; }
        public DateTimeOffset DateOfPost { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
